using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfileEngine.Core.Interfaces;
using ProfileEngine.Core.Model.ProfileAggregate;

namespace ProfileEngine.Core.Model
{
    /// <summary>
    /// Represents a limit on the number of times an Act can be counted in a single day
    /// </summary>
    public class DayLimit : IAchievementLimit
    {
        private const int NumberOfDaysInPeriod = 1;
        private readonly Act _limitedAct;

        private readonly DateTime _periodStart;

        private readonly int _maximumPerPeriod;

        public DayLimit(Act limitedAct, DateTime periodStart, int maximumPerPeriod)
        {
            this._maximumPerPeriod = maximumPerPeriod;
            this._periodStart = periodStart;
            this._limitedAct = limitedAct;
        }

        public bool LimitExceeded(IQueryable<ProfileAggregate.Act> recentActivity)
        {
            return recentActivity.Count(a => a.ActivityId == _limitedAct.ActivityId && a.OccurredOnUtc >= _periodStart) > _maximumPerPeriod;
        }
    }
}
