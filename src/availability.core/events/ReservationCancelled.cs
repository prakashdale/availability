using availability.core.entities;
using availability.core.valueObjects;

namespace availability.core.events {
    public class ReservationCancelled: IDomainEvent{
        public Resource Resource{get;}
        public Reservation Reservation{get;}
        public ReservationCancelled(Resource resource, Reservation reservation) => (Resource, Reservation) = (resource, reservation);
    }
}
