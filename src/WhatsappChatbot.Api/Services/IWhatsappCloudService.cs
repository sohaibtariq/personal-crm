namespace WhatsappChatbot.Api.Services;

public interface IWhatsappCloudService
{
    Task SendTextMessage(string message, string recipient);
    
    bool VerifyToken(string hubVerifyToken);
}