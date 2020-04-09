using MsgPack.Serialization;
using System;
using System.IO;

namespace Comparison_SignalR_Display
{
    class Program
    {
        static void Main()
        {
            var person = GenerateStandardPerson();
            var serializer = MessagePackSerializer.Get<Person>();

            byte[] serializedPerson;
            using (var stream = new MemoryStream())
            {
                serializer.Pack(stream, person);
                serializedPerson = stream.ToArray();
            }

            Console.WriteLine(string.Join(", ", serializedPerson));
            Console.WriteLine();
            Console.WriteLine("Bytes Count: " + serializedPerson.Length);//172 bytes
        }

        public static Person GenerateStandardPerson()
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
