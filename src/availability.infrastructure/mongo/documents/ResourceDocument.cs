using System;
using System.Collections.Generic;
using Convey.Types;

namespace availability.infrastructure.mongo.documents {
    internal sealed class ResourceDocument:IIdentifiable<Guid> {
        public Guid Id {get;set;}
        public int Version {get;set;}
        public IEnumerable<string> Tags{get;set;}
        public IEnumerable<ReservationDocument> Reservations{get;set;}
        
    } 
}