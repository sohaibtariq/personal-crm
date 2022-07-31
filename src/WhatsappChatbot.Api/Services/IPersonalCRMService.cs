
using PersonalCRM.Standard.Models;

namespace WhatsappChatbot.Api.Services
{
    public interface IPersonalCRMService
    {
        Task DeleteScheduledMessage(int id);
        Task<List<Contact>> GetContacts();
        Task<List<ScheduledMessage>> GetScheduledMessages();
        Task UpdateContact(Contact contact);
    }
}