using System.Collections.Generic;
using Convey.CQRS.Events;
using availability.core.events;

namespace availability.application.services
{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
    }
}