using System;
using ProfileEngine.Core.Interfaces;

namespace ProfileEngine.Core.Model.Events
{
    public class TelerikTweetRetweeted : IDomainEvent
    {
        public Guid ProfileId { get; set; }
        public Guid ActivityId { get; set; }
        public DateTime OccurredOnUtc { get; set; }
        public string Details { get; set; }
    }
}