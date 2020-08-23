using availability.core.entities;

namespace availability.core.events {
    public class ResourceCreated: IDomainEvent{
        public Resource Resource{get;}
        public ResourceCreated(Resource resource) => Resource = resource;
    }
}
