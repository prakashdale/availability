using System;
using availability.application.dto;
using Convey.CQRS.Queries;

namespace availability.application.queries {
    public class GetResource: IQuery<ResourceDto>{
        public Guid ResourceId{get;set;}

    }

}