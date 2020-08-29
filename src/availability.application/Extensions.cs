using System.Runtime.CompilerServices;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;

[assembly: InternalsVisibleTo("availability.application.Tests.Unit")]
namespace availability.application
{
    public static class Extensions
    {
        public static IConveyBuilder AddApplication(this IConveyBuilder builder)
            => builder
                .AddCommandHandlers()
                .AddEventHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryEventDispatcher();
    }
}