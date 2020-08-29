using availability.core.entities;
using availability.core.valueObjects;

namespace availability.core.events
{
    public class ReservationCanceled : IDomainEvent
    {
        public Resource Resource { get; }
        public Reservation Reservation { get; }

        public ReservationCanceled(Resource resource, Reservation reservation)
            => (Resource, Reservation) = (resource, reservation);
    }
}