using System;
using FluentScheduler;
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


        public void ScheduleTouchpoints(List<Contact> contacts)
        {
            if (contacts.Equals(null) || contacts.Count == 0)
            {
                return ;
            }

            foreach (var contact in contacts)
            {

                JobManager.AddJob(
                    () => SendTouchPoint(contact),
                    s => s.WithName($"touchpoint_{contact.Number}").ToRunEvery(contact.Cadence).Days()
                );
            }

        }


        private void SendTouchPoint(Contact contact)
        {
                var touchpointMessage = TouchpointMessage(contact.Name);

                //NOTE: scheduling async tasks are problematic with Fluentscheduler, so making the method synchronous for now
                _whatsappCloudService.SendTextMessage(touchpointMessage, contact.Number.ToString()).GetAwaiter().GetResult();

                UpdateLastContact(contact).GetAwaiter().GetResult();


        }


        public void ScheduleBirthdayMessages(List<Contact> contacts)
        {
            if (contacts.Equals(null) || contacts.Count == 0)
            {
                return;
            }

            foreach (var contact in contacts)
            {

                JobManager.AddJob(
                    () => SendBirthdayMessage(contact),
                    s => s.WithName($"birthday_{contact.Number}").ToRunOnceAt(contact.Birthday).AndEvery(12).Months()
                );
            }

        }



        private void SendBirthdayMessage(Contact contact)
        {
                var birthdayMessage = BirthdayMessage(contact.Name);
                _whatsappCloudService.SendTextMessage(birthdayMessage, contact.Number.ToString()).GetAwaiter().GetResult();

                 UpdateLastContact(contact).GetAwaiter().GetResult();

        }


        public void ScheduleScheduledMessages(List<ScheduledMessage> messages)
        {
            if (messages.Equals(null) || messages.Count == 0)
            {
                return;
            }

            foreach (var message in messages)
            {

                JobManager.AddJob(
                    () => SendScheduledMessage(message),
                    s => s.WithName($"message_{message.Number}_{message.Id}").ToRunOnceAt(message.Timestamp)
                );
            }

        }

        private void SendScheduledMessage(ScheduledMessage message)
        {
          
                _whatsappCloudService.SendTextMessage(message.Message, message.Number).GetAwaiter().GetResult();
                _personalCRMService.DeleteScheduledMessage(message.Id).GetAwaiter().GetResult();

                //var contact = contacts.Where(contact => contact.Number.Equals(message.Number))
                //    .FirstOrDefault();
                //if (contact != null)
                //    await UpdateLastContact(contact);    
                   

        }

        public void RemoveAllBirthdayJobs()
        {
            var birthdayJobs = JobManager.RunningSchedules.Where(s => s.Name.Contains("birthday"));
            foreach (var job in birthdayJobs)
            {
                JobManager.RemoveJob(job.Name);
            }
        }

        public void RemoveAllTouchpointJobs()
        {
            var touchpointJobs = JobManager.RunningSchedules.Where(s => s.Name.Contains("touchpoint"));
            foreach (var job in touchpointJobs)
            {
                JobManager.RemoveJob(job.Name);
            }
        }

        public void RemoveAllMessageJobs()
        {
            var messageJobs = JobManager.RunningSchedules.Where(s => s.Name.Contains("message"));
            foreach (var job in messageJobs)
            {
                JobManager.RemoveJob(job.Name);
            }
        }


        private string BirthdayMessage(string name)
        {
            var message = $"Happy Birthday {name}!";
            return message;
        }
        private string TouchpointMessage(string name)
        {
            var message = $"Hey, how's it going {name}?";
            return message;
        }
        private async Task UpdateLastContact(Contact contact)
        {
            contact.LastContact = DateTime.Now;
            await _personalCRMService.UpdateContact(contact);
        }

        private void DeleteScheduledJob(string prefix, string number, string id)
        {
            string jobName = string.IsNullOrEmpty(id) ? $"{prefix}_{number}" : $"{prefix}_{number}_{id}";
            JobManager.RemoveJob(jobName);
        }
    }
}

