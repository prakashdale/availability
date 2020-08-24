using System.Linq;
using availability.application.dto;
using availability.core.entities;
using availability.core.valueObjects;

namespace availability.infrastructure.mongo.documents {
    internal static class Extensions{
        public static Resource AsEntity(this ResourceDocument document) 
        => new Resource(document.Id, document.Tags, 
        document.Reservations?.Select(x => new Reservation(x.From, x.To, x.Priority)), document.Version);

        public static ResourceDocument AsDocument(this Resource resource)
        => new ResourceDocument{
            Id = resource.Id,
            Version = resource.Version,
            Tags = resource.Tags,
            Reservations = resource.Reservations?.Select(x => new ReservationDocument{
                From = x.From,
                To = x.To,
                Priority = x.Priority
            })
        };

        public static ResourceDto AsDto(this ResourceDocument document)
        => new ResourceDto{
            Id = document.Id,
            Tags = document.Tags,
            Reservations = document.Reservations.Select(x => new ReservationDto{
                From = x.From,
                To = x.To,
                Priority = x.Priority
            })
        };
    }

}