using System;
using System.Linq;

namespace Web.Models
{
    public class ProfileMember
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string LastActivityDateString { get; set; }
    }
}