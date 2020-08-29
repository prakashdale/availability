using System;
using Convey.CQRS.Queries;
using availability.application.dto;

namespace availability.application.queries
{
    public class GetResource : IQuery<ResourceDto>
    {
        public Guid ResourceId { get; set; }
    }
}