using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;

namespace Core.Services
{
    public class ProfileLevelService
    {
        public ProfileLevel GetLevelForPoints(int points)
        {
            return GetLevels().Last(l => points >= l.PointsRequired);
        }

        public List<ProfileLevel> GetLevels()
        {
            var levels = new List<ProfileLevel>();

            int pointsRequired = 0;
            for (int i = 0; i < 50; i++)
            {
                if (i == 1)
                {
                    pointsRequired = 1000;
                }
                else
                {
                    pointsRequired = pointsRequired + (i / 2 * 1000);
                }
                levels.Add(new ProfileLevel() { Level = i + 1, Name = "Ninja " + (i+1), PointsRequired = pointsRequired });
            }

            return levels.OrderBy(l => l.PointsRequired).ToList();
        }
    }
}
