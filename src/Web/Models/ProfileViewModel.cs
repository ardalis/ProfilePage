using System;
using System.Collections.Generic;
using System.Linq;

namespace Web.Models
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public string RealName { get; set; }
        public string ShortBio { get; set; }
        public string BlogName { get; set; }
        public string BlogUrl { get; set; }
        public string TwitterAlias { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string StackOverflowUsername { get; set; }
        public string PluralsightUsername { get; set; }
        public string GitHubUsername { get; set; }
        public string JoinDateString { get; set; }
        public string LastActivityTimeSpanString { get; set; }
        public int CurrentLevel { get; set; }
        public int NextLevel { get; set; }
        public int PointsTowardNextLevel { get; set; }
        public int PointsRequiredForNextLevel { get; set; }
        public int PercentCompleteForNextLevel { get; set; }
        public List<ActivityViewModel> SuggestedActivities { get; set; }
        public List<AchievementProgressViewModel> AchievementsInProgress { get; set; }
    }

    public class ActivityViewModel
    {
        public int Points { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class AchievementProgressViewModel
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public int CompletedUnits { get; set; }
        public int RequiredUnits { get; set; }
        public int PercentComplete { get; set; }
    }
}