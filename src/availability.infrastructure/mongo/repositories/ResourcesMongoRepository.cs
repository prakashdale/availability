using System;
using System.Threading.Tasks;
using availability.core.entities;
using availability.core.repositories;
using availability.infrastructure.mongo.documents;
using Convey.Persistence.MongoDB;

namespace availability.infrastructure.mongo.repositories {
    internal sealed class ResourcesMongoRepository : IResourceRepository
    {
        private readonly IMongoRepository<ResourceDocument, Guid> _repo;

        public ResourcesMongoRepository(IMongoRepository<ResourceDocument, Guid> repo) => _repo = repo;
        public async Task AddAsync(Resource resource)
        => await _repo.AddAsync(resource.AsDocument());

        public async Task DeleteAsync(AggregateId id)
        => await _repo.DeleteAsync(id);

        public async Task<Resource> GetAsync(AggregateId id)
        {
            var doc = await _repo.GetAsync(id);
            return doc?.AsEntity();
        }

        public async Task UpdateAsync(Resource resource)
        => await _repo.UpdateAsync(resource.AsDocument(), x => x.Id == resource.Id && x.Version < resource.Version );

    }

}