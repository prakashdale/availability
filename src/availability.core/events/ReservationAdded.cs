using availability.core.entities;
using availability.core.valueObjects;

namespace availability.core.events {
    public class ReservationAdded: IDomainEvent{
        public Resource Resource{get;}
        public Reservation Reservation{get;}
        public ReservationAdded(Resource resource, Reservation reservation) => (Resource, Reservation) = (resource, reservation);
    }
}
