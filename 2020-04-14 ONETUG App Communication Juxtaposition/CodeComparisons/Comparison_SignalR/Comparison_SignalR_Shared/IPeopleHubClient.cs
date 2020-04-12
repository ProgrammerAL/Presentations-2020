using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comparison_SignalR_Shared
{
    public interface IPeopleHubClient
    {
        Task ReceiveUpdatedPerson(Person person);//Return type Task on all client methods
    }
}
