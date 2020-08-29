using availability.core.entities;
using availability.core.valueObjects;

namespace availability.core.events
{
    public class ReservationReleased : IDomainEvent
    {
        public Resource Resource { get; }
        public Reservation Reservation { get; }

        public ReservationReleased(Resource resource, Reservation reservation)
            => (Resource, Reservation) = (resource, reservation);
    }
}