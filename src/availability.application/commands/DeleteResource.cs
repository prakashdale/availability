using System;
using Convey.CQRS.Commands;

namespace availability.application.commands
{
    [Contract]
    public class DeleteResource : ICommand
    {
        public Guid ResourceId { get; }

        public DeleteResource(Guid resourceId)
            => ResourceId = resourceId;
    }
}