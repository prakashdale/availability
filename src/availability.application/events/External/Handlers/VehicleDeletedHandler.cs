using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using availability.application.commands;
using availability.application.events.external;

namespace availability.Application.Events.External.Handlers
{
    public class VehicleDeletedHandler : IEventHandler<VehicleDeleted>
    {
        private readonly ICommandDispatcher _dispatcher;

        public VehicleDeletedHandler(ICommandDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public Task HandleAsync(VehicleDeleted @event) => _dispatcher.SendAsync(new DeleteResource(@event.VehicleId));
    }
}