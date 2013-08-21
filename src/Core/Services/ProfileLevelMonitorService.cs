using System;
using System.Linq;

namespace Core.Services
{
    public class ProfileLevelMonitorService
    {
        private readonly ActivityService _activityService;

        public ProfileLevelMonitorService(ActivityService activityService)
        {
            this._activityService = activityService;
            this._activityService.Logged += _activityService_Logged;
        }

        void _activityService_Logged(object sender, ActLoggedEventArgs e)
        {
            var act = e.Act;

            // update profile from act

            // check for level increase and fire event if level increased
        }


    }
}
