using System.Threading.Tasks;
using Convey.CQRS.Events;

namespace availability.application.events.external.handlers
{
    public class CustomerCreatedHandler : IEventHandler<CustomerCreated>
    {
        // Customer data could be saved into custom DB depending on the business requirements.
        // Given the asynchronous nature of events, this would result in eventual consistency.
        public Task HandleAsync(CustomerCreated @event)
            => Task.CompletedTask;
    }
}