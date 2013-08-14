﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Web.Hubs;

namespace Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private static System.Timers.Timer UpdateTimer;

        protected void Application_Start()
        {
            RouteTable.Routes.MapHubs();
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            SetupTimer();
        }

        void SetupTimer()
        {
            UpdateTimer = new System.Timers.Timer(10000);
            UpdateTimer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateTime_Elapsed);
            UpdateTimer.Interval = 5000;
            UpdateTimer.Enabled = true;
        }

        private void UpdateTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Random rnd = new Random();
            UpdateTimer.Interval = rnd.Next(5000, 15000);
            ProfileHub.Trigger();
        }
    }
}