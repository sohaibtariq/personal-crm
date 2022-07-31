using System;
using PersonalCRM.Standard;
using PersonalCRM.Standard.Models;

namespace WhatsappChatbot.Api.Services
{
    public class PersonalCRMService : IPersonalCRMService
    {
        private readonly PersonalCRMClient _personalCRMClient;
        private readonly ILogger<PersonalCRMService> _logger;

        public PersonalCRMService(PersonalCRMClient personalCRMClient, ILogger<PersonalCRMService> logger)
        {
            _personalCRMClient = personalCRMClient;
            _logger = logger;
        }


        public async Task<List<Contact>> GetContacts()
        {
            try
            {
                var contacts = await _personalCRMClient.MiscController.GetContactsAsync();
                return contacts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to fetch data from sheet");
                throw;
            }
        }

        public async Task<List<ScheduledMessage>> GetScheduledMessages()
        {
            try
            {
                var messages = await _personalCRMClient.MiscController.GetScheduledMessagesAsync();
                return messages;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to fetch schedulued messages from Sheet");
                throw;

            }        
        }

        public async Task DeleteScheduledMessage(int id)
        {
            try
            {
                await _personalCRMClient.MiscController.DeleteScheduledMessageAsync(1, "and",id);
                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to delete message from Sheet");
                throw;
            }
        }

        public async Task UpdateContact(Contact contact)
        {
            try
            {
                await _personalCRMClient.MiscController.UpdateContactAsync(1, "or", contact, null, null, contact.Id);
                return;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to delete message from Sheet");
                throw;
            }
        }
   }
}


 