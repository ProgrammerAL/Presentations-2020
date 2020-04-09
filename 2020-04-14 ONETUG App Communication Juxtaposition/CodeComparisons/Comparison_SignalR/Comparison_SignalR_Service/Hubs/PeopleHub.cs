using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Comparison_SignalR_Service.Hubs
{
    public interface IPeopleHubClient
    {
        Task ReceiveUpdatedPerson(Person person);//Return type Task on all client methods
    }

    public interface IPeopleHubServer
    {
        Task AlertListnersPersonIsUpdated(Person person);
    }

    public class PeopleHub : Hub<IPeopleHubClient>, IPeopleHubServer
    {
        public async Task AlertListnersPersonIsUpdated(Person person)
        {
            //await Clients.All.SendAsync("ReceiveUpdatedPerson", person);
            await Clients.All.ReceiveUpdatedPerson(person);
        }
    }
}
