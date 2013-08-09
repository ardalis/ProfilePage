using System;
using System.Linq;
using System.Web.Mvc;

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
            return View();
        }

    }
}
