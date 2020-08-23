using System.Threading.Tasks;
using availability.core.entities;

namespace availability.core.repositories {
    public interface IResourceRepository
    {
        Task<Resource> GetAsync(AggregateId id);
        Task AddAsync(Resource resource);
        Task UpdateAsync(Resource resource);
        Task DeleteAsync(AggregateId id);
        
    }

}