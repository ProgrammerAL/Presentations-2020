using Comparison_SignalR_Service.Hubs;
using Comparison_SignalR_Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comparison_SignalR_Service
{
    public class PersonUpdater
    {
        private readonly IHubContext<PeopleHub, IPeopleHubClient> _peopleHub;
        private readonly Task<Task> _continuallyRunTask;

        public PersonUpdater(IHubContext<PeopleHub, IPeopleHubClient> peopleHub)
        {
            _peopleHub = peopleHub;
            _continuallyRunTask = new Task<Task>(ContinuouslyRunAsync, TaskCreationOptions.LongRunning);
            _continuallyRunTask.Start();
        }

        private async Task ContinuouslyRunAsync()
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));

                var person = GenerateStandardPerson();
                await _peopleHub.Clients.All.ReceiveUpdatedPerson(person);
            }
        }

        private Person GenerateStandardPerson()
        {
            return new Person
            {
                Id = 5,
                FirstName = "Homer",
                LastName = "Simpson",
                EmailAddress = "HomerJay42@Simpson.co.uk",
                AllowedEmailTypes = new[] { EmailType.HappyBirthday, EmailType.Promotional },
                FamilyMemberIds = new[] { 1, 2, 3, 4, 6, 7, 8, 9 },
                Preferences = new[]
                {
                    new Setting { Name = "AllowCookies", Value = "true" },
                    new Setting { Name = "DonutPreference", Value = "Pink with Sprinkles" },
                    new Setting { Name = "LoginGreetingDisplayed", Value = "Welcome Homer" },
                }
            };
        }
    }
}
