using System;
using FluentScheduler;
using Microsoft.Extensions.Options;
using WhatsappChatbot.Api.Models;

namespace WhatsappChatbot.Api.Services
{
    public class ScheduleRegistry: Registry
    {
        IScheduledServices _scheduledServices;
        public ScheduleRegistry(IScheduledServices scheduledServices, IOptions<ScheduledTaskConfig> options)
        {
            _scheduledServices = scheduledServices;

 //           Schedule(() => _scheduledServices.SendBirthdayMessage()).ToRunEvery(options.Value.BirthdayMessage).Minutes();
 //           Schedule(() => _scheduledServices.SendTouchPoint()).ToRunEvery(options.Value.Touchpoint).Minutes();
            Schedule(() => _scheduledServices.SendScheduledMessage()).ToRunEvery(options.Value.ScheduledMessage).Minutes();

        }
    }
}

