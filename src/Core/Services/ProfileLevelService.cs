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

        private List<ProfileLevel> GetLevels()
        {
            var levels = new List<ProfileLevel>();

            levels.Add(new ProfileLevel() { Level = 1, Name = "One", PointsRequired = 0 });
            levels.Add(new ProfileLevel() { Level = 2, Name = "Two", PointsRequired = 1000 });
            levels.Add(new ProfileLevel() { Level = 3, Name = "Three", PointsRequired = 2000 });

            return levels.OrderBy(l => l.PointsRequired).ToList();
        }
    }
}
