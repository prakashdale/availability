using availability.core.entities;

namespace availability.core.events
{
    public class ResourceDeleted : IDomainEvent
    {
        public Resource Resource { get; }

        public ResourceDeleted(Resource resource)
            => Resource = resource;
    }
}