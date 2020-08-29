using System.Collections.Generic;
using System.Threading.Tasks;
using availability.application.services;
using availability.core.events;
using Microsoft.Extensions.Logging;

namespace availability.infrastructure.services {
    public sealed class EventProcessor : IEventProcessor
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IEventMapper _eventMapper;
        private readonly ILogger<EventProcessor> _logger;

        public EventProcessor(IMessageBroker messageBroker,  IEventMapper eventMapper, ILogger<EventProcessor> logger)
        {
            _messageBroker = messageBroker;
            _eventMapper = eventMapper;
            _logger = logger;
        }
        public async Task ProcessAsync(IEnumerable<IDomainEvent> events)
        {
            if (events is null) {
                return;
            }

            _logger.LogTrace("Processing domain events...");
            foreach (var @event in events)
            {
                //handle domain event
            }

            _logger.LogTrace("Processing integration events...");
            var integrationEvents = _eventMapper.MapAll(events);
            await _messageBroker.PublishAsync(integrationEvents);
        }
    }

}