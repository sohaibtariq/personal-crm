
using PersonalCRM.Standard.Models;

namespace WhatsappChatbot.Api.Services
{
    public interface IScheduledServices
    {
        void RemoveAllBirthdayJobs();
        void RemoveAllMessageJobs();
        void RemoveAllTouchpointJobs();
        void ScheduleBirthdayMessages(List<Contact> contacts);
        void ScheduleScheduledMessages(List<ScheduledMessage> messages);
        void ScheduleTouchpoints(List<Contact> contacts);
        
    }
}