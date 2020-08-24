using System.Threading.Tasks;
using availability.application.dto;
using availability.application.queries;
using availability.infrastructure.mongo.documents;
using Convey.CQRS.Queries;
using MongoDB.Driver;

namespace availability.infrastructure.mongo.queries.handlers {
    public sealed class GetResourceHandler : IQueryHandler<GetResource, ResourceDto>
    {
        private readonly IMongoDatabase _database;
        
        public GetResourceHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<ResourceDto> HandleAsync(GetResource query)
        {var document = await _database.GetCollection<ResourceDocument>("resources")
                .Find(r => r.Id == query.ResourceId)
                .SingleOrDefaultAsync();
            
            
            return document?.AsDto();
        }
    }

}