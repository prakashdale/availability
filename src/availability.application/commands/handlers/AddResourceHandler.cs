
using System.Threading.Tasks;
using availability.application.events;
using availability.application.exceptions;
using availability.application.services;
using availability.core.entities;
using availability.core.repositories;
using Convey.CQRS.Commands;

namespace availability.application.commands.handlers {
    internal sealed class AddResourceHandler : ICommandHandler<AddResource>
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IEventProcessor _eventProcessor;

        public AddResourceHandler(IResourceRepository resourceRepository, IEventProcessor eventProcessor)
        {
            _resourceRepository = resourceRepository;
            _eventProcessor = eventProcessor;            
        }
        public async Task HandleAsync(AddResource command)
        {
            var resource = await _resourceRepository.GetAsync(command.ResourceId);
            if (resource is {}) {
                throw new ResourceAlreadyExistsException(command.ResourceId);
            }

            resource = Resource.Create(command.ResourceId, command.Tags);
            await _resourceRepository.AddAsync(resource);
            await _eventProcessor.ProcessAsync(resource.Events);
        }
    }
}