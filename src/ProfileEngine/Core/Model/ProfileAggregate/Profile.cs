using System;
using System.Linq;
using ProfileEngine.Core.Interfaces;

namespace ProfileEngine.Core.Model.ProfileAggregate
{
    public class Profile : IEntity
    {
        public System.Guid Id { get; private set; }
    }
}