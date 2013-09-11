using System.Threading.Tasks;

namespace ProfileEngine.Core.Interfaces
{
    public interface IRaiseEvent 
    {
        Task Raise<T>(T domainEvent) where T : IDomainEvent;
    }
}