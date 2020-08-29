using System;

namespace availability.core.exceptions {
    public class CannotExpropriateReservationException : DomainException
    {
        public Guid ResourceId {get;}
        public CannotExpropriateReservationException(Guid resourceId, int priority, DateTime from, DateTime to) : base($"Reservation with priority '{priority}' already exests for the date '{from.Date}'")
        {
            ResourceId = resourceId;
        }
    }
}