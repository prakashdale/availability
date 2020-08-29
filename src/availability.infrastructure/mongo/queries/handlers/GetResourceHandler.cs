using System.Threading.Tasks;
using Convey.CQRS.Queries;
using MongoDB.Driver;
using availability.application.dto;
using availability.application.queries;
using availability.infrastructure.mongo.documents;


namespace availability.infrastructure.mongo.queries.handlers
{
    internal sealed class GetResourceHandler : IQueryHandler<GetResource, ResourceDto>
    {
        private readonly IMongoDatabase _database;

        public GetResourceHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<ResourceDto> HandleAsync(GetResource query)
        {
            var document = await _database.GetCollection<ResourceDocument>("resources")
                .Find(r => r.Id == query.ResourceId)
                .SingleOrDefaultAsync();
            
            return document?.AsDto();
        }
    }
}