using System.Threading.Tasks;

namespace ProfileEngine.Core.Interfaces
{
    public interface IHandleEvent<T> where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }

    public interface IRaiseEvent 
    {
        Task Raise<T>(T domainEvent) where T : IDomainEvent;
    }
}