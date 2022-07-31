using System;
using PersonalCRM.Standard.Models;

namespace WhatsappChatbot.Api.Services
{
    public class ScheduledServices : IScheduledServices
    {
        ILogger<ScheduledServices> _logger;
        IWhatsappCloudService _whatsappCloudService;
        IPersonalCRMService _personalCRMService;

        public ScheduledServices(ILogger<ScheduledServices> logger, IWhatsappCloudService whatsappCloudService, IPersonalCRMService personalCRMService)
        {
            _logger = logger;
            _whatsappCloudService = whatsappCloudService;
            _personalCRMService = personalCRMService;
        }

        public async Task<bool> SendTouchPoint()
        {
            var contacts = await _personalCRMService.GetContacts();

            if (contacts.Equals(null) || contacts.Count == 0)
            {
                return false;
            }

            var touchpointContacts = contacts.Where(contact =>
            (DateTime.Now - contact.LastContact).TotalDays >= contact.Cadence);

            foreach (var contact in touchpointContacts)
            {
                var touchpointMessage = TouchpointMessage(contact.Name);
                await _whatsappCloudService.SendTextMessage(touchpointMessage, contact.Number.ToString());

                await UpdateLastContact(contact);
            }

            return true;

        }

        public async Task<bool> SendBirthdayMessage()
        {
            var contacts = await _personalCRMService.GetContacts();

            if (contacts.Equals(null) || contacts.Count == 0)
            {
                return true;
            }

            var birthdayContacts = contacts.Where(contact =>
           (contact.Birthday.Date == DateTime.Now.Date) && contact.LastContact.Date != DateTime.Now.Date);


            foreach (var contact in birthdayContacts)
            {
                var birthdayMessage = BirthdayMessage(contact.Name);
                await _whatsappCloudService.SendTextMessage(birthdayMessage, contact.Number.ToString());

                await UpdateLastContact(contact);

            }

            return true;

        }

        public async Task<bool> SendScheduledMessage()
        {
            var messages = await _personalCRMService.GetScheduledMessages();
            var contacts = await _personalCRMService.GetContacts();

            if (messages.Equals(null) || messages.Count == 0)
            {
                return true;
            }

            var scheduledMessages = messages.Where(message =>
           (message.Timestamp >= DateTime.Now));

            foreach (var message in scheduledMessages)
            {
                await _whatsappCloudService.SendTextMessage(message.Message, message.Number);
                await _personalCRMService.DeleteScheduledMessage(message.Id);

                var contact = contacts.Where(contact => contact.Number.Equals(message.Number))
                    .FirstOrDefault();
                if (contact != null)
                    await UpdateLastContact(contact);    
                   
            }



            return true;

        }

        private string BirthdayMessage(string name)
        {
            var message = $"Happy Birthday {name}!";
            return message;
        }
        private string TouchpointMessage(string name)
        {
            var message = $"Hey, how is it going {name}?";
            return message;
        }
        private async Task UpdateLastContact(Contact contact)
        {
            contact.LastContact = DateTime.Now;
            await _personalCRMService.UpdateContact(contact);
        }
    }
}

