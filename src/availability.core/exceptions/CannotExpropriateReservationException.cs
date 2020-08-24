using System;

namespace availability.core.exceptions {
    public class CannotExpropriateReservationException : DomainException
    {
        public CannotExpropriateReservationException(int priority, DateTime from, DateTime to) : base($"Reservation with priority '{priority}' already exests for the date '{from.Date}'")
        {
        }
    }
}