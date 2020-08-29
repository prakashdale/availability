using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace availability.application.events.external
{
    [Message("vehicles")]
    public class VehicleDeleted : IEvent
    {
        public Guid VehicleId { get; }

        public VehicleDeleted(Guid vehicleId)
            => VehicleId = vehicleId;
    }
}