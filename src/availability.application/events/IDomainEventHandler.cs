using System.Threading.Tasks;
using availability.core.events;

namespace availability.application.events
{
    public interface IDomainEventHandler<in T> where T : class, IDomainEvent
    {
        Task HandleAsync(T @event);
    }
}