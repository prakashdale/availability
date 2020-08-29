using System.Collections.Generic;
using System.Linq;
using availability.application.events;
using availability.application.services;
using availability.core.events;
using Convey.CQRS.Events;

namespace availability.infrastructure.services {
    internal sealed class EventMapper : IEventMapper
    {
        public IEvent Map(IDomainEvent @event)
        => @event switch {
            ResourceCreated e => new ResourceAdded(e.Resource.Id),
            ReservationAdded e => new ResourceReserved(e.Resource.Id, e.Reservation.From, e.Reservation.To),
            ReservationCancelled e => new ResourceReservationCancelled(e.Resource.Id, e.Reservation.From, e.Reservation.To),
            _ => null
        };

        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
        => events.Select(Map);
    }
}