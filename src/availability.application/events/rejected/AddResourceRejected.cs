
using System;
using Convey.CQRS.Events;

namespace availability.application.events.rejected {
    [Contract]
    public class AddResourceRejected : IRejectedEvent
    {
        public AddResourceRejected(Guid resourceId, string code, string reason)
        {
            ResourceId = resourceId;
            Code = code;
            Reason = reason;
        }

        public Guid ResourceId {get;}
        public string Reason {get;}

        public string Code {get;}
    }

    
}