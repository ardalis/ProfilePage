using System.Collections.Generic;
using ProfileEngine.Core.Interfaces;

namespace ProfileEngine.Core.Model.AchievementAggregate
{
    public class Achievement : IEntity
    {
        public System.Guid Id { get; private set; }
        public string PointValue { get; set; }
        public string Level { get; set; }
        public List<ActivityRequired> Prerequisites { get; set; }
        public List<IAchievementLimit> Limits { get; set; }
    }
}