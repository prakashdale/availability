using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Convey.MessageBrokers.Outbox;

namespace availability.infrastructure.decorators {
    internal sealed class OutboxCommandHandlerDecorator<T> : ICommandHandler<T> where T : class, ICommand
    {
        private readonly ICommandHandler<T> handler;
        private readonly IMessageOutbox outbox;

        public Task HandleAsync(T command)
        {
            throw new System.NotImplementedException();
        }
        public OutboxCommandHandlerDecorator(ICommandHandler<T> handler, IMessageOutbox outbox)
        {
            this.handler = handler;
            this.outbox = outbox;
        }
    }

}