using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comparison_SignalR_Shared
{
    public interface IPeopleHubServer
    {
        Task AlertListnersPersonIsUpdated(Person person);
        Task<string> SayHello(string name);
    }
}
