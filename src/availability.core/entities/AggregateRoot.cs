using System.Collections.Generic;
using System.Linq;
using availability.core.events;

namespace availability.core.entities {
    public abstract class AggregateRoot {
        public AggregateId Id {get; protected set;}
        public int Version {get; protected set;}
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public IEnumerable<IDomainEvent> Events => _events;
        protected void AddEvent(IDomainEvent @event) {
            if (!_events.Any()) {
                Version++;
            }

            _events.Add(@event);
        }

        public void ClearEvents() => _events.Clear();

        
    }
}