using System;
using System.Collections.Generic;
using Convey.CQRS.Commands;

namespace availability.application.commands {
    public class ReserveResource: ICommand {
        
        public Guid ResourceId{get;}
        public DateTime From {get;}
        public DateTime To {get;}
        public int Priority {get;}
        public ReserveResource(Guid resourceId, DateTime from, DateTime to, int priority)
        {
            ResourceId = resourceId;
            From = from;
            To = to;
            Priority = priority;
        }
    }
}