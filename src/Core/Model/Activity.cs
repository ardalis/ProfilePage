using System;

namespace Core.Model
{
    /// <summary>
    /// An Activity is a broad class of Acts.  
    /// e.g. "Retweeted a Telerik twitter account"
    /// </summary>
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointValue { get; set; }
    }
}