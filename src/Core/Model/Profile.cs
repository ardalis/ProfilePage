using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model.Events;
using Core.Services;

namespace Core.Model
{

    public class Profile
    {
        public event NewLevelAchievedEventHandler NewLevelAchieved;

        public Profile()
        {
            Id = Guid.NewGuid();
        }

        public Profile(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
        public int Points { get; set; }
        public IList<Act> History { get; private set; }

        public void ApplyPoints(int points, ProfileLevelService profileLevelService)
        {
            int currentPoints = Points;
            var currentLevel = profileLevelService.GetLevelForPoints(currentPoints);

            Points = currentPoints + points;

            var newLevel = profileLevelService.GetLevelForPoints(Points);
            if (newLevel.Level > currentLevel.Level)
            {
                NewLevelAchieved(this, new NewLevelAchievedEventArgs(this));
            }

        }
    }

}