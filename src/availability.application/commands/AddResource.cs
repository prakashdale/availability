using System;
using System.Collections.Generic;
using Convey.CQRS.Commands;

namespace availability.application.commands {
    public class AddResource: ICommand {
        public Guid ResourceId {get;}
        public IEnumerable<string> Tags{get;}
        public AddResource(Guid resourceId, IEnumerable<string> tags)
        {
            ResourceId = resourceId;
            Tags = tags;
        }
    }
}