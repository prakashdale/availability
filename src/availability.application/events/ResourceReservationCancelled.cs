using System;
using Convey.CQRS.Events;

namespace availability.application.events {
    [Contract]
    public class ResourceReservationCancelled: IEvent{
        public Guid ResourceId{get;}
        public DateTime From{get;}
        public DateTime To{get;}
        public ResourceReservationCancelled(Guid resourceId, DateTime from, DateTime to) {
            ResourceId = resourceId;
            From = from;
            To = to;
        } 

    }

}