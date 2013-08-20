using System;
using System.Linq;

namespace Core.Model
{
    public class ProfileLevel
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public int PointsRequired { get; set; }

        public override string ToString()
        {
            return String.Format("{0} Points Required: {1}", Name, PointsRequired);
        }
    }
}