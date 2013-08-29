using System;
using ProfileEngine.Core.Interfaces;

namespace ProfileEngine.Core.Model.ProfileAggregate
{
    public class Act : IEntity
    {
        public System.Guid Id { get; private set; }
        public Guid ProfileId { get; set; }
        public Guid ActivityId { get; set; }
        public DateTime OccurredOnUtc { get; set; }

    }
}