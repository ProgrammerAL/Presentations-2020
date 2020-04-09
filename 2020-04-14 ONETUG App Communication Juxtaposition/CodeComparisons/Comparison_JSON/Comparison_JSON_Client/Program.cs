using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Comparison_JSON_Client
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Press Enter to begin...");
            _ = Console.ReadLine();

            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44343")
            };

            var helloResponse = await client.GetAsync("/people/hello?name=Homer");
            var helloResponseBody = await helloResponse.Content.ReadAsStringAsync();
            Console.WriteLine(helloResponseBody);

            var findPersonResponse = await client.GetAsync("/people/person?id=5");
            var findPersonResponseBody = await findPersonResponse.Content.ReadAsStringAsync();
            var person = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(findPersonResponseBody);
            Console.WriteLine(person.Id + " " + person.FirstName + " " + person.LastName);

            _ = Console.ReadLine();
        }
    }
}
