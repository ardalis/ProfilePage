using System;
using System.Collections.Generic;
using System.Linq;
using ProfileEngine.Core.Interfaces;
using ProfileEngine.Core.Model.AchievementAggregate;
using ProfileEngine.Core.Model.ProfileAggregate;

namespace ProfileEngine.Core.Services
{
    /// <summary>
    /// This service monitors a queue of activities and applies them to the appropriate profile.
    /// </summary>
    public class ActivityProcessorService
    {
        private readonly List<Achievement> _achievements;

        private readonly IDateTime _dateTime;

        public ActivityProcessorService(List<Achievement> achievements, IDateTime dateTime)
        {
            this._dateTime = dateTime;
            this._achievements = achievements;
        }

        /// <summary>
        /// Retrieves the next event from the activity queue and applies it to the appropriate profile
        /// </summary>
        public void ProcessActivityQueueItem()
        {
            var act = new Act();
            var profile = new Profile();

            // get a list of achievements that have this act as a prerequisite
            var achievementsToCheck = _achievements.Where(a => a.Prerequisites.Any(p => p.ActivityId == act.ActivityId));

            foreach (var achievement in achievementsToCheck)
            {
                // check if achievement's limits have already been exceeded
                foreach (var limit in achievement.Limits)
                {
                    if (limit.LimitExceeded(null)) // TODO: fix limit so it gets activity stream here
                    {
                        continue;
                    }
                }

                // check if prerequisites have been fulfilled within time limit
                bool triggerAchievement = true;
                foreach (var prerequisite in achievement.Prerequisites)
                {
                    int countInWindow = profile.History.Count(a => (a.ActivityId == prerequisite.ActivityId)
                        && (a.OccurredOnUtc >= _dateTime.UtcNow() - prerequisite.ActivityWindow));
                    if (countInWindow < prerequisite.NumberRequired)
                    {
                        triggerAchievement = false;
                    }
                }
                if (triggerAchievement)
                {
                    // raise Achievement Unlocked Event
                }
            }

        }
    }
}
