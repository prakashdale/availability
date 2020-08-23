
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;

namespace availability.application {
    public static class Extensions {
        public static IConveyBuilder AddApplication(this IConveyBuilder builder) 
        => builder
            .AddCommandHandlers()
            .AddEventHandlers()
            .AddInMemoryCommandDispatcher()
            .AddInMemoryEventDispatcher();
    }
}