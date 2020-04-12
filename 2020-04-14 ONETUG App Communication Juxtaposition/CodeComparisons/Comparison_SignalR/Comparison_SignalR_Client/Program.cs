using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Comparison_SignalR_Shared;

namespace Comparison_SignalR_Client
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Press Enter to begin...");
            _ = Console.ReadLine();

            var hubEndpoint = "https://localhost:44370/PeopleHub";
            var connection = new HubConnectionBuilder()
                .WithUrl(hubEndpoint)
                .AddMessagePackProtocol()//MessagePack not on by default
                .WithAutomaticReconnect()//Automatic Reconnect on by default now, wasn't always
                .Build();

            await connection.StartAsync();
            connection.Closed += Connection_Closed;
            connection.Reconnected += Connection_Reconnected;


            var receiverDisposable = connection.On<Person>(nameof(IPeopleHubClient.ReceiveUpdatedPerson), ReceiveUpdatedPerson);

            //var helloResult = await connection.InvokeAsync<string>("SayHello", arg1: "Homer");
            var helloResult = await connection.InvokeAsync<string>(nameof(IPeopleHubServer.SayHello), arg1: "Homer");
            Console.WriteLine("HelloResult: " + helloResult);

            while (true)
            {
                await Task.Delay(1_000);
            }
        }

        private static void ReceiveUpdatedPerson(Person person)
        {
            Console.WriteLine("Received Updated Person: " + person.Id + " " + person.FirstName + " " + person.LastName);
        }

        private static Task Connection_Closed(Exception arg)
        {
            Console.WriteLine("Connection Closed: " + arg.ToString());
            return Task.CompletedTask;
        }

        private static Task Connection_Reconnected(string arg)
        {
            Console.WriteLine("Connection Reconnected: " + arg);
            return Task.CompletedTask;
        }
    }
}
