using System;
using System.Linq;
using Core.Model;

namespace Core.Interfaces
{
    public interface IActivityRepository
    {
        Activity Get(Guid id);

        void Save(Activity activity);
    }
}