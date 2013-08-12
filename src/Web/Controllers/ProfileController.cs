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
                JoinDateString="August 2013"
            };
            return View(model);
        }

        public ActionResult LeaderboardData()
        {
            var members = new List<ProfileMember>()
            {
                new ProfileMember() { Name="Ardalis", Level=70 },
                new ProfileMember() { Name="Brendoneus", Level=69 },
                new ProfileMember() { Name="Eric", Level=2 }
            };
            return Json(members, JsonRequestBehavior.AllowGet);
        }
    }
}
