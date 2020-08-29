using System;
using Convey.CQRS.Events;

namespace availability.application.events.rejected
{
    [Contract]
    public class DeleteResourceRejected : IRejectedEvent
    {
        public Guid ResourceId { get; }
        public string Reason { get; }
        public string Code { get; }

        public DeleteResourceRejected(Guid resourceId, string reason, string code)
            => (ResourceId, Reason, Code) = (resourceId, reason, code);
    }
}