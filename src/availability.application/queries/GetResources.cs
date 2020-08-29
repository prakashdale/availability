using System.Collections.Generic;
using Convey.CQRS.Queries;
using availability.application.dto;

namespace availability.application.queries
{
    public class GetResources : IQuery<IEnumerable<ResourceDto>>
    {
        public IEnumerable<string> Tags { get; set; }
        public bool MatchAllTags { get; set; }
    }
}