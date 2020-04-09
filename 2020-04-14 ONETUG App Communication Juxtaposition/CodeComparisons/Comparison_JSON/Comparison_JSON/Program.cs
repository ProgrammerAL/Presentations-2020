using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Comparison_JSON
{
    class Program
    {
        static void Main()
        {
            var person = GenerateStandardPerson();
            var newtonsoftSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(person);
            var netCoreSerialized = System.Text.Json.JsonSerializer.Serialize(person);
            Console.WriteLine("Newtonsoft and .NET Core Serialized The Same: " + newtonsoftSerialized == netCoreSerialized);//True
            Console.WriteLine("Serialized Length: " + newtonsoftSerialized.Length);//323 characters

            var jsonBytes = Encoding.UTF8.GetBytes(newtonsoftSerialized);
            byte[] compressedBytes;

            using (var compressedStream = new MemoryStream())
            {
                var lengthBytes = BitConverter.GetBytes(jsonBytes.Length);
                compressedStream.Write(lengthBytes, 0, 4);

                using (var compressionStream = new GZipStream(compressedStream,
                    CompressionMode.Compress))
                {
                    compressionStream.Write(jsonBytes, 0, jsonBytes.Length);
                    compressionStream.Flush();
                }
                
                compressedBytes = compressedStream.ToArray();
            }

            Console.WriteLine("Compressed Length: " + compressedBytes.Length);//244 bytes
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
