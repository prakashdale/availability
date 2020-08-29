using System;
using Convey.CQRS.Events;

namespace availability.application.events
{
    [Contract]
    public class ResourceReservationCanceled : IEvent
    {
        public Guid ResourceId { get; }
        public DateTime DateTime { get; }

        public ResourceReservationCanceled(Guid resourceId, DateTime dateTime)
            => (ResourceId, DateTime) = (resourceId, dateTime);
    }
}