using System;
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
    }
}