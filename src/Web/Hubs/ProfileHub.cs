using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        internal static void Trigger()
        {
            Debug.Print("ProfileHub.Trigger()");
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ProfileHub>();
            context.Clients.All.updateBoard();
        }
    }
}