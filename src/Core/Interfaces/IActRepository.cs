using System;
using System.Linq;
using Core.Model;

namespace Core.Interfaces
{
    public interface IActRepository
    {
        Act Get(Guid id);

        void Save(Act act);
    }
}