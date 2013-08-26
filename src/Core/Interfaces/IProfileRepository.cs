using System;
using Core.Model;

namespace Core.Interfaces
{
    public interface IProfileRepository
    {
        Profile Get(Guid id);

        void Save(Profile activity);
    }
}