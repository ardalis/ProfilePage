using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Profile",
                url: "{profileName}",
                defaults: new { controller = "Profile", action = "Index", profileName = "" }
            );

            routes.MapRoute(
                name: "LeaderboardData",
                url: "Profile/LeaderboardData",
                defaults: new { controller = "Profile", action = "LeaderboardData" }
            );
        }
    }
}