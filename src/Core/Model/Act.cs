using System;
using System.Linq;

namespace Core.Model
{
    /// <summary>
    /// An Act is a particular instance of an Activity
    /// e.g. "Profile {id} Retweeted Tweet {tweet} from account {account} on {date}"
    /// 
    /// Should Acts be in a separate bounded context from Profile?
    /// </summary>
    public class Act
    {
        public Act(Guid id, Guid profileId, Guid activityId, DateTime utcDateOfAct, string details)
        {
            this.Details = details;
            this.UtcDateOfAct = utcDateOfAct;
            this.ActivityId = activityId;
            this.ProfileId = profileId;
            this.Id = id;
        }

        public Guid Id { get; private set; }
        public Guid ProfileId { get; private set; }
        public Guid ActivityId { get; private set; }
        public DateTime UtcDateOfAct { get; private set; }
        public string Details { get; private set; }
    }
}