using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileEngine.Core.Interfaces;

namespace ProfileEngine.Infrastructure.Events
{
    public class EventHandler : IRaiseEvent
    {
        private readonly StructureMap.IContainer _container;

        public EventHandler(StructureMap.IContainer container)
        {
            this._container = container;
        }

        public System.Threading.Tasks.Task Raise<T>(T domainEvent) where T : IDomainEvent
        {
            var handlers = _container.GetAllInstances<IHandleEvent<IDomainEvent>>();
            var task = Task.Factory.StartNew(() => RaiseAction(handlers, domainEvent));
            return task;
        }

        private void RaiseAction<T>(IEnumerable<IHandleEvent<IDomainEvent>> handlers, T domainEvent) where T : IDomainEvent
        {
            try
            {
                Parallel.ForEach(handlers, h => h.Handle(domainEvent));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
