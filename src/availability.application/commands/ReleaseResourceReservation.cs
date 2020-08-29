using System;
using Convey.CQRS.Commands;

namespace availability.application.commands
{
    [Contract]
    public class ReleaseResourceReservation : ICommand
    {
        public Guid ResourceId { get; }
        public DateTime DateTime { get; }

        public ReleaseResourceReservation(Guid resourceId, DateTime dateTime)
            => (ResourceId, DateTime) = (resourceId, dateTime);
    }
}