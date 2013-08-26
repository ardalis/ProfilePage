using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using Core.Model;

namespace Infrastructure.Repositories
{
    public class ActRepository : IActRepository
    {
        private static Dictionary<Guid, Act> _acts = new Dictionary<Guid, Act>();
        public Act Get(Guid id)
        {
            return _acts[id];
        }

        public void Save(Act act)
        {
            if (_acts.ContainsKey(act.Id))
            {
                _acts[act.Id] = act;
            }
            else
            {
                _acts.Add(act.Id, act);
            }
        }
    }
}
