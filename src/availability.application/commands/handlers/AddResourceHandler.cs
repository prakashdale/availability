using System.Threading.Tasks;
using availability.application.services;
using availability.application.exceptions;
using availability.core.repositories;
using Convey.CQRS.Commands;
using availability.core.entities;

namespace availability.application.commands.handlers
{
    internal sealed class AddResourceHandler : ICommandHandler<AddResource>
    {
        private readonly IResourcesRepository _repository;
        private readonly IEventProcessor _eventProcessor;

        public AddResourceHandler(IResourcesRepository repository, IEventProcessor eventProcessor)
        {
            _repository = repository;
            _eventProcessor = eventProcessor;
        }
        
        public async Task HandleAsync(AddResource command)
        {
            if (await _repository.ExistsAsync(command.ResourceId))
            {
                throw new ResourceAlreadyExistsException(command.ResourceId);
            }
            
            var resource = Resource.Create(command.ResourceId, command.Tags);
            await _repository.AddAsync(resource);
            await _eventProcessor.ProcessAsync(resource.Events);
        }
    }
}