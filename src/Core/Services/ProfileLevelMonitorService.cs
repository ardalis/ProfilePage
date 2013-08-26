using System;
using System.Linq;
using Core.Interfaces;
using Core.Model;

namespace Core.Services
{
    public delegate void ProfileNewLevelAchievedEventHandler(object sender, ProfileNewLevelAchievedEventArgs e);

    public class ProfileLevelMonitorService
    {
        private readonly ActLoggerService _activityService;
        private readonly IActivityRepository _activityRepository;
        private readonly IProfileRepository _profileRepository;

        public event ProfileNewLevelAchievedEventHandler ProfileNewLevelAchieved;

        public ProfileLevelMonitorService(ActLoggerService activityService,
            IActivityRepository activityRepository,
            IProfileRepository profileRepository)
        {
            this._profileRepository = profileRepository;
            this._activityRepository = activityRepository;
            this._activityService = activityService;
            this._activityService.Logged += _activityService_Logged;
        }

        void _activityService_Logged(object sender, ActLoggedEventArgs e)
        {
            var act = e.Act;

            var activity = _activityRepository.Get(act.ActivityId);
            var profile = _profileRepository.Get(act.ProfileId);

            profile.NewLevelAchieved += (o, i) =>
                {
                    ProfileNewLevelAchieved(o, new ProfileNewLevelAchievedEventArgs(o as Profile, act));
                };

            profile.ApplyPoints(activity.PointValue, new ProfileLevelService());
        }
    }

    public class ProfileNewLevelAchievedEventArgs : EventArgs
    {
        public ProfileNewLevelAchievedEventArgs(Profile profile, Act act)
        {
            this.Profile = profile;
            this.Act = act;
        }

        public Act Act { get; private set; }
        public Profile Profile { get; private set; }
    }
}
