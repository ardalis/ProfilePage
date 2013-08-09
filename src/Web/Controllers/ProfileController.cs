using System;
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
                LinkedInUrl = "http://www.linkedin.com/in/stevenandrewsmith/"
            };
            return View(model);
        }

    }
}
