using System.Threading.Tasks;
using Convey.CQRS.Commands;

using availability.application.services;
using availability.core.repositories;
using availability.application.exceptions;

namespace availability.application.commands.handlers
{
    internal sealed class DeleteResourceHandler : ICommandHandler<DeleteResource>
    {
        private readonly IResourcesRepository _repository;
        private readonly IEventProcessor _eventProcessor;

        public DeleteResourceHandler(IResourcesRepository repository, IEventProcessor eventProcessor)
        {
            _repository = repository;
            _eventProcessor = eventProcessor;
        }
        
        public async Task HandleAsync(DeleteResource command)
        {
            var resource = await _repository.GetAsync(command.ResourceId);
            
            if (resource is null)
            {
                throw new ResourceNotFoundException(command.ResourceId);
            }

            resource.Delete();
            await _repository.DeleteAsync(resource.Id);
            await _eventProcessor.ProcessAsync(resource.Events);
        }
    }
}