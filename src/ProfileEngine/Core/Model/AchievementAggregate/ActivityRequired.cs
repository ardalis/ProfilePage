using System;

namespace ProfileEngine.Core.Model.AchievementAggregate
{
    public class ActivityRequired
    {
        public Guid ActivityId { get; set; }
        public int NumberRequired { get; set; }
        public TimeSpan ActivityWindow { get; set; }
    }
}