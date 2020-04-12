using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Comparison_JSON_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        [HttpGet("Hello")]
        public Task<string> GetHello(string name)
        {
            return Task.FromResult("Hello " + name);
        }

        [HttpGet("Person")]
        public Task<Person> GetPerson(int personId)
        {
            var person = GenerateStandardPerson();
            return Task.FromResult(person);
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
