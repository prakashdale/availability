using System;
using Convey.CQRS.Events;

namespace availability.application.events {
    [Contract]
    public class ResourceAdded: IEvent {
        public Guid ResourceId {get;}
        public ResourceAdded(Guid resourceId)
        {
            ResourceId = resourceId;
        }
    }
}