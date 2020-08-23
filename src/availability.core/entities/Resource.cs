using System.Collections.Generic;
using System.Linq;
using availability.core.events;
using availability.core.exceptions;
using availability.core.valueObjects;

namespace availability.core.entities{
    public class Resource: AggregateRoot {
        private ISet<string> _tags = new HashSet<string>();
        private ISet<Reservation> _reservations = new HashSet<Reservation>();
        public IEnumerable<string> Tags {
            get => _tags;
            private set => new HashSet<string>(value);
        }
        public IEnumerable<Reservation> Reservations {
            get => _reservations;
            private set => new HashSet<Reservation>(value);
        }

        public Resource(AggregateId id, IEnumerable<string> tags, IEnumerable<Reservation> reservations = null, int version = 0)
        {
            ValidateTags(tags);
            Id = id;
            Tags = tags;
            Reservations = reservations ?? Enumerable.Empty<Reservation>();
            Version = version;
            
        }

        private static void ValidateTags(IEnumerable<string> tags) {
            if (tags is null || !tags.Any()) {
                throw new MissingResourceTagsException();

            }
            if (tags.Any(string.IsNullOrWhiteSpace)) {
                throw new InvalidResourceTagsException();
            }

        }

        public static Resource Create(AggregateId id, IEnumerable<string> tags, IEnumerable<Reservation> reservations = null) {
            var resource = new Resource(id, tags, reservations);
            resource.AddEvent(new ResourceCreated(resource));
            return resource;
        }

    }
}