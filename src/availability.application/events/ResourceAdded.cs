using System;
using availability.application;
using Convey.CQRS.Events;
using Convey.Types;
namespace availability.application.events
{
    [Contract]
    public class ResourceAdded : IEvent
    {
        public Guid ResourceId { get; }

        public ResourceAdded(Guid resourceId)
            => ResourceId = resourceId;
    }
}