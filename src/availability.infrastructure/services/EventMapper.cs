using System.Collections.Generic;
using System.Linq;
using Convey.CQRS.Events;
using availability.application.events;
using availability.application.services;
using availability.core.events;
using ReservationCanceled = availability.core.events.ReservationCanceled;
using ResourceDeleted = availability.core.events.ResourceDeleted;


namespace availability.infrastructure.services
{
    internal sealed class EventMapper : IEventMapper
    {
        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
            => events.Select(Map);

        public IEvent Map(IDomainEvent @event)
            => @event switch
            {
                ResourceCreated e => (IEvent) new ResourceAdded(e.Resource.Id),
                ResourceDeleted e => new application.events.ResourceDeleted(e.Resource.Id),
                ReservationAdded e => new ResourceReserved(e.Resource.Id, e.Reservation.DateTime),
                ReservationReleased e => new ResourceReservationReleased(e.Resource.Id, e.Reservation.DateTime),
                ReservationCanceled e => new ResourceReservationCanceled(e.Resource.Id, e.Reservation.DateTime),
                _ => null
            };
    }
}