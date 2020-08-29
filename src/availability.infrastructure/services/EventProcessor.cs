using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using availability.application.events;
using availability.application.services;
using availability.core.events;


namespace availability.infrastructure.services
{
    internal sealed class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;
        private readonly ILogger<IEventProcessor> _logger;

        public EventProcessor(IServiceScopeFactory serviceScopeFactory, IEventMapper eventMapper,
            IMessageBroker messageBroker, ILogger<IEventProcessor> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
            _logger = logger;
        }

        public async Task ProcessAsync(IEnumerable<IDomainEvent> events)
        {
            if (events is null)
            {
                return;
            }

            _logger.LogTrace("Processing domain events...");
            var integrationEvents = await HandleDomainEvents(events);
            if (!integrationEvents.Any())
            {
                return;
            }

            _logger.LogTrace("Processing integration events...");
            await _messageBroker.PublishAsync(integrationEvents);
        }

        private async Task<List<IEvent>> HandleDomainEvents(IEnumerable<IDomainEvent> events)
        {
            var integrationEvents = new List<IEvent>();
            using var scope = _serviceScopeFactory.CreateScope();
            foreach (var @event in events)
            {
                var eventType = @event.GetType();
                _logger.LogTrace($"Handling domain event: {eventType.Name}");
                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(eventType);
                dynamic handlers = scope.ServiceProvider.GetServices(handlerType);
                foreach (var handler in handlers)
                {
                    await handler.HandleAsync((dynamic) @event);
                }

                var integrationEvent = _eventMapper.Map(@event);
                if (integrationEvent is null)
                {
                    continue;
                }

                integrationEvents.Add(integrationEvent);
            }

            return integrationEvents;
        }
    }
}