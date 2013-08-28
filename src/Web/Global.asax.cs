using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Core.Model;
using Infrastructure.Repositories;
using Web.Hubs;
using Core.Services;

namespace Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private static System.Timers.Timer UpdateTimer;
        private static ProfileRepository ProfileRepository;
        private static Guid ProfileId;

        protected void Application_Start()
        {
            RouteTable.Routes.MapHubs();
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ProfileRepository = new ProfileRepository();
            ProfileId = Guid.NewGuid();
            ProfileRepository.Save(new Profile(ProfileId));

            this.SetupTimer();
        }

        void SetupTimer()
        {
            UpdateTimer = new System.Timers.Timer(10000);
            UpdateTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.UpdateTime_Elapsed);
            UpdateTimer.Interval = 5000;
            UpdateTimer.Enabled = true;
        }

        private void UpdateTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Random rnd = new Random();
            UpdateTimer.Interval = rnd.Next(5000, 15000);
            var profile = ProfileRepository.Get(ProfileId);
            profile.NewLevelAchieved += (o, i) =>
            {
                var levelService = new ProfileLevelService();
                var currentLevel = levelService.GetLevelForPoints(profile.Points);
                ProfileHub.Trigger("Leveled Up", "Congrats on reaching level " + currentLevel);
            };
            profile.ApplyPoints(500, new Core.Services.ProfileLevelService());
            ProfileHub.ProfilePoints();
        }
    }
}