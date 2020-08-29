using System;
using Convey.CQRS.Events;
using Convey.Types;

namespace availability.application.events.rejected
{
    [Contract]
    public class AddResourceRejected : IRejectedEvent
    {
        public Guid ResourceId { get; }
        public string Reason { get; }
        public string Code { get; }

        public AddResourceRejected(Guid resourceId, string reason, string code)
            => (ResourceId, Reason, Code) = (resourceId, reason, code);
    }
}