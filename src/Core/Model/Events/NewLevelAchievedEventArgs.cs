using System;

namespace Core.Model.Events
{
    public class NewLevelAchievedEventArgs : EventArgs
    {
        public NewLevelAchievedEventArgs(Profile profile)
        {
            this.Profile = profile;
        }

        public Profile Profile { get; private set; }
    }
}