using WhatsappChatbot.Api.Services;
using WhatsAppCloudAPI.Standard;
using Microsoft.AspNetCore.Mvc;
using WhatsappChatbot.Api.Models;
using PersonalCRM.Standard;
using FluentScheduler;
using PersonalCRM.Standard.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<WhatsappConfig>(builder.Configuration.GetSection("Whatsapp"));
builder.Services.Configure<ScheduledTaskConfig>(builder.Configuration.GetSection("SchedluedTasks"));

builder.Services.AddSingleton<WhatsAppCloudAPIClient>(_ =>
    new WhatsAppCloudAPIClient.Builder()
        .AccessToken(builder.Configuration.GetValue<string>("Whatsapp:AccessToken"))
        .HttpClientConfig(config => config.NumberOfRetries(0))
        .Build());

builder.Services.AddSingleton<PersonalCRMClient>(_ =>
    new PersonalCRMClient.Builder()
    .HttpClientConfig(config => config.NumberOfRetries(0))
    .Build());

builder.Services.AddSingleton<IWhatsappCloudService, WhatsappCloudService>();
builder.Services.AddSingleton<IPersonalCRMService, PersonalCRMService>();
builder.Services.AddSingleton<IScheduledServices, ScheduledServices>();
builder.Services.AddSingleton<ScheduleRegistry>();

var app = builder.Build();
app.UseHttpLogging();

JobManager.Initialize(app.Services.GetService<ScheduleRegistry>());
JobManager.JobException += info => app.Logger.LogError("An error just happened with a scheduled job: " + info.Exception);
JobManager.JobStart += info => app.Logger.LogInformation($"{info.Name}: started");
JobManager.JobEnd += info => app.Logger.LogInformation($"{info.Name}: ended ({info.Duration})");


app.MapGet("api/Webhook", (
        [FromQuery(Name = "hub.mode")] string? hubMode,
        [FromQuery(Name = "hub.challenge")] int? hubChallenge,
        [FromQuery(Name = "hub.verify_token")] string? hubVerifyToken, IWhatsappCloudService whatsappCloudService)
    =>
{
    if (string.IsNullOrEmpty(hubMode) || string.IsNullOrEmpty(hubVerifyToken))
        return Results.BadRequest("hubMode or hubVerifyToken is empty");
    if (!hubMode.Equals("subscribe") || !whatsappCloudService.VerifyToken(hubVerifyToken))
        return Results.BadRequest("Unable to verify token");
    return Results.Ok(hubChallenge);
});


app.MapGet("api/refreshContacts", async (IScheduledServices scheduledServices, IPersonalCRMService personalCrmService) =>
{
    scheduledServices.RemoveAllBirthdayJobs();
    scheduledServices.RemoveAllTouchpointJobs();

    var contacts = await personalCrmService.GetContacts();

    scheduledServices.ScheduleBirthdayMessages(contacts);
    scheduledServices.ScheduleTouchpoints(contacts);
    
    return Results.Ok();

});


app.MapGet("api/refreshMessages", async (IScheduledServices scheduledServices, IPersonalCRMService personalCrmService) =>
{
    scheduledServices.RemoveAllMessageJobs();

    var scheduledMessages = await personalCrmService.GetScheduledMessages();
    scheduledServices.ScheduleScheduledMessages(scheduledMessages);

    return Results.Ok();

});

#region admin endpoints

app.MapGet("api/admin/contacts", async (IPersonalCRMService personalCRMService) =>
{
    var contacts = await personalCRMService.GetContacts();
    return Results.Ok(contacts);

});

app.MapGet("api/admin/testMessage", async ([FromQuery(Name = "message")] string message, [FromQuery(Name = "number")] string number, IWhatsappCloudService whatsappCloudService) =>
{
    await whatsappCloudService.SendTextMessage(message, number);
    return Results.Ok();

});

app.MapGet("api/admin/messages", async (IPersonalCRMService personalCRMService) =>
{
    var messages = await personalCRMService.GetScheduledMessages();
    return Results.Ok(messages);
});
#endregion

app.Map("/", async (httpContext) =>
    await httpContext.Response.WriteAsync("Friends and Family is up and running"));



app.Run();