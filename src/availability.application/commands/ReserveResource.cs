using System;
using Convey.CQRS.Commands;

namespace availability.application.commands
{
    [Contract]
    public class ReserveResource : ICommand
    {
        public Guid ResourceId { get; }
        public DateTime DateTime { get; }
        public int Priority { get; }
        public Guid CustomerId { get; }

        public ReserveResource(Guid resourceId, DateTime dateTime, int priority, Guid customerId)
            => (ResourceId, DateTime, Priority, CustomerId) = (resourceId, dateTime, priority, customerId);
    }
}