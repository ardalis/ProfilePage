using System;
using System.Linq;

namespace Core.Model
{
    public class Profile
    {
        public Profile()
        {
            Id = Guid.NewGuid();
        }

        public Profile(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
        public int Points { get; private set; }
    }
}