using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comparison_SignalR_Shared;
using Microsoft.AspNetCore.SignalR;

namespace Comparison_SignalR_Service.Hubs
{
    public class PeopleHub : Hub<IPeopleHubClient>, IPeopleHubServer
    {
        public async Task AlertListnersPersonIsUpdated(Person person)
        {
            //await Clients.All.SendAsync("ReceiveUpdatedPerson", person);
            await Clients.All.ReceiveUpdatedPerson(person);
        }

        public Task<string> SayHello(string name)
        {
            return Task.FromResult("Hello " + name);
        }
    }
}
