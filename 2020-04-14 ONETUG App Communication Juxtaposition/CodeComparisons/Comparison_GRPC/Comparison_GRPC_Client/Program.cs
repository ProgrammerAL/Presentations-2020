using Comparison_GRPC;
using Grpc.Net.Client;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Comparison_GRPC_Client
{
    class Program
    {
        static async Task Main()
        {
            while (true)
            {
                Console.WriteLine("Current Process Id: " + Process.GetCurrentProcess().Id);
                Console.WriteLine("Press Enter to begin...");
                _ = Console.ReadLine();

                var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new Peopler.PeoplerClient(channel);

                var helloResponse = await client.SayHelloAsync(new HelloRequest() { Name = "Homer" });
                Console.WriteLine(helloResponse.Message);

                var findPersonResponse = await client.GetPersonAsync(new FindPersonRequest() { Id = 1 });
                Console.WriteLine(findPersonResponse.FirstName);
            }
        }
    }
}
