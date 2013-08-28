using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNet.SignalR;

namespace Web.Hubs
{
    public class ProfileHub : Hub
    {
        public void Hello()
        {
            this.Clients.All.hello();
        }

        internal static void Trigger(string title, string message)
        {
            Debug.Print("ProfileHub.Trigger()");
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ProfileHub>();
            //context.Clients.All.updateBoard();
            context.Clients.All.notify(title, message);
        }
    }
}