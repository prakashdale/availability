using System;
using Convey.CQRS.Events;

namespace availability.application.events
{
    [Contract]
    public class ResourceReservationReleased : IEvent
    {
        public Guid ResourceId { get; }
        public DateTime DateTime { get; }

        public ResourceReservationReleased(Guid resourceId, DateTime dateTime)
            => (ResourceId, DateTime) = (resourceId, dateTime);
    }
}