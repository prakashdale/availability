using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace availability.application.events.external
{
    [Message("customers")]
    public class CustomerCreated : IEvent
    {
        public Guid CustomerId { get; }

        public CustomerCreated(Guid customerId)
            => CustomerId = customerId;
    }
}