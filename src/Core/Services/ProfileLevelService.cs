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
            return GetLevels().First(l => points >= l.PointsRequired);
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
            //levels.Add(new ProfileLevel() { Level = 1, Name = "One", PointsRequired = 0 });
            //levels.Add(new ProfileLevel() { Level = 2, Name = "Two", PointsRequired = 1000 });
            //levels.Add(new ProfileLevel() { Level = 3, Name = "Three", PointsRequired = 2000 });
            //levels.Add(new ProfileLevel() { Level = 4, Name = "Four", PointsRequired = 3000 });
            //levels.Add(new ProfileLevel() { Level = 5, Name = "Five", PointsRequired = 5000 });
            //levels.Add(new ProfileLevel() { Level = 6, Name = "Six", PointsRequired = 8000 });
            //levels.Add(new ProfileLevel() { Level = 7, Name = "Seven", PointsRequired = 10000 });

            return levels.OrderBy(l => l.PointsRequired).ToList();
        }
    }
}
