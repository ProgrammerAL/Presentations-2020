using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Comparison_GRPC
{
    public class PeoplerService : Peopler.PeoplerBase
    {
        private readonly ILogger<PeoplerService> _logger;
        public PeoplerService(ILogger<PeoplerService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<Person> GetPerson(FindPersonRequest request, ServerCallContext context)
        {
            var person = GenerateStandardPerson();
            return Task.FromResult(person);
        }

        private Person GenerateStandardPerson()
        {
            var person = new Person
            {
                Id = 5,
                FirstName = "Homer",
                LastName = "Simpson",
                EmailAddress = "HomerJay42@Simpson.co.uk",
            };

            //Note: NOT and array
            person.AllowedEmailTypes.AddRange(new[] { EmailType.HappyBirthday, EmailType.Promotional });
            person.FamilyMemberIds.AddRange(new[] { 1, 2, 3, 4, 6, 7, 8, 9 });
            person.Preferences.AddRange(new[]
                {
                    new Setting { Name = "AllowCookies", Value = "true" },
                    new Setting { Name = "DonutPreference", Value = "Pink with Sprinkles" },
                    new Setting { Name = "LoginGreetingDisplayed", Value = "Welcome Homer" },
                });

            return person;
        }
    }
}
