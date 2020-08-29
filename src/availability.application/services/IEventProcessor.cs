using System.Collections.Generic;
using System.Threading.Tasks;
using availability.core.events;

namespace availability.application.services {
    public interface IEventProcessor
    {
        Task ProcessAsync(IEnumerable<IDomainEvent> @events);
    }
}