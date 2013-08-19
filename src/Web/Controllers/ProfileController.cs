using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index(string profileName)
        {
            if(String.IsNullOrEmpty(profileName))
            {
                return View("Leaderboard");
            }
            var model = new ProfileViewModel()
            {
                Name = "Ardalis",
                RealName = "Steve Smith",
                ShortBio = "EVP, Services, Telerik",
                BlogName = "Ardalis.com",
                BlogUrl = "http://ardalis.com",
                TwitterAlias="ardalis",
                FacebookUrl="http://facebook.com/StevenAndrewSmith",
                LinkedInUrl = "http://www.linkedin.com/in/stevenandrewsmith/",
                StackOverflowUsername = "ssmith",
                PluralsightUsername = "steve-smith",
                GitHubUsername="ardalis",
                JoinDateString="August 2013",
                LastActivityTimeSpanString="5 seconds ago",
                CurrentLevel=21,
                NextLevel=22,
                PointsTowardNextLevel=460,
                PointsRequiredForNextLevel=1000,
                PercentCompleteForNextLevel=46,
                SuggestedActivities=GetSuggestedActivities(),
                AchievementsInProgress=GetAchievementsInProgress()
            };
            return View(model);
        }

        private List<AchievementProgressViewModel> GetAchievementsInProgress()
        {
            return new List<AchievementProgressViewModel>()
            {
                new AchievementProgressViewModel()
                {
                    Name="Pluralsight Scholar II",
                    Description="Watch five Pluralsight courses on Telerik products.",
                    ImageName="pluralsight-achievement.png",
                    CompletedUnits=1,
                    RequiredUnits=5,
                    PercentComplete=20
                },
                new AchievementProgressViewModel()
                {
                    Name="StackOverflow Ninja III",
                    Description="Provide 10 answers to Telerik product-tagged questions.",
                    ImageName="stackoverflow-achievement.png",
                    CompletedUnits=3,
                    RequiredUnits=10,
                    PercentComplete=30
                }
            };
        }

        private List<ActivityViewModel> GetSuggestedActivities()
        {
            return new List<ActivityViewModel>()
            {
                new ActivityViewModel()
                {
                    Points=1500,
                    Name="Submit a testimonial",
                    Description="Share your opinion about our products and services."
                },
                new ActivityViewModel()
                {
                    Points=5000,
                    Name="Submit a case study",
                    Description="Share your successful project that used Telerik products."
                },
                new ActivityViewModel()
                {
                    Points=50,
                    Name="ReTweet a Telerik Announcement",
                    Description="Share Telerik's announcements with your followers on Twitter."
                }
            };
        }

        [OutputCache(Duration=600, VaryByParam="None")]
        public ActionResult LeaderboardData()
        {
            var members = new List<ProfileMember>()
            {
                new ProfileMember() { Name="Ardalis", Level=70, LastActivityDateString=DateTime.UtcNow.ToString("o") },
                new ProfileMember() { Name="Brendoneus", Level=69, LastActivityDateString=DateTime.UtcNow.AddDays(-5).ToString("o") },
                new ProfileMember() { Name="Eric", Level=2, LastActivityDateString=DateTime.UtcNow.AddHours(-1).ToString("o") },
                new ProfileMember() { Name=DateTime.Now.ToString(), Level=0, LastActivityDateString=DateTime.UtcNow.ToString("o") }
            };
            return Json(members, JsonRequestBehavior.AllowGet);
        }
    }
}
