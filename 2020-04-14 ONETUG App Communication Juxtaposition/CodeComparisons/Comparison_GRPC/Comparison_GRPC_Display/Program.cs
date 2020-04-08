using Comparison_GRPC;
using System;
using System.IO;
using System.Text;

namespace Comparison_GRPC_Display
{
    class Program
    {
        static void Main()
        {
            var person = GenerateStandardPerson();

            var serializedPerson = Google.Protobuf.MessageExtensions.ToByteArray(person);

            Console.WriteLine(string.Join(", ", serializedPerson));
            Console.WriteLine();
            Console.WriteLine("Bytes Count: " + serializedPerson.Length);//161 bytes
        }

        private static Person GenerateStandardPerson()
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
