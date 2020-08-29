using System;
using Convey.CQRS.Events;

namespace availability.application.events {
    [Contract]
    public class ResourceReserved: IEvent{
        public Guid ResourceId{get;}
        public DateTime From{get;}
        public DateTime To{get;}
        public ResourceReserved(Guid resourceId, DateTime from, DateTime to) {
            ResourceId = resourceId;
            From = from;
            To = to;
        } 

    }

}