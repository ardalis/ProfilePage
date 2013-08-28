using System;
using System.Linq;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;

namespace Web.Hubs
{
    public class ProfileHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        internal static void Trigger(string title, string message)
        {
            Debug.Print("ProfileHub.Trigger()");
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ProfileHub>();
            context.Clients.All.updateBoard(title, message);
        }

        internal static void ProfilePoints()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ProfileHub>();
            context.Clients.All.updatePoints();
        }
    }
}