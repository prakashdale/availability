using System;
using Convey.CQRS.Events;

namespace availability.application.events.rejected
{
    [Contract]
    public class ReleaseResourceReservationRejected : IRejectedEvent
    {
        public Guid ResourceId { get; }
        public DateTime DateTime { get; }
        public string Reason { get; }
        public string Code { get; }

        public ReleaseResourceReservationRejected(Guid resourceId, DateTime dateTime, string reason, string code)
            => (ResourceId, DateTime, Reason, Code) = (resourceId, dateTime, reason, code);
    }
}