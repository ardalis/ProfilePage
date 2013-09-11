using System.Threading.Tasks;

namespace ProfileEngine.Core.Interfaces
{
    public interface IHandleEvent<T> where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }
}