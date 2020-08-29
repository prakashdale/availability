
using System.Collections.Generic;
using availability.core.events;
using Convey.CQRS.Events;

namespace availability.application.services {
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> @events);
    }
}