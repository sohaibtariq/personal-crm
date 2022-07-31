
namespace WhatsappChatbot.Api.Services
{
    public interface IScheduledServices
    {
        Task<bool> SendBirthdayMessage();
        Task<bool> SendScheduledMessage();
        Task<bool> SendTouchPoint();
    }
}