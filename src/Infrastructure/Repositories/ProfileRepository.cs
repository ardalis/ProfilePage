using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using Core.Model;

namespace Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private static Dictionary<Guid, Profile> _profiles = new Dictionary<Guid, Profile>();
        public Profile Get(Guid id)
        {
            return _profiles[id];
        }

        public void Save(Profile profile)
        {
            if (_profiles.ContainsKey(profile.Id))
            {
                _profiles[profile.Id] = profile;
            }
            else
            {
                _profiles.Add(profile.Id, profile);
            }
        }
    }
}
