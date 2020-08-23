using System;
using System.Collections.Generic;
using availability.application.dto;
using Convey.CQRS.Queries;

namespace availability.application.queries {
    public class GetResources: IQuery<IEnumerable<ResourceDto>>{
        public IEnumerable<string> Tags {get; set;}
        public bool MatchAllTags {get;set;}


    }

}