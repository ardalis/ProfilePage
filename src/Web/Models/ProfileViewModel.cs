using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}