using System;
using System.Collections.Generic;
using Convey.Types;

namespace availability.infrastructure.mongo.documents {
    internal sealed class ReservationDocument {
        public DateTime From {get;set;}
        public DateTime To {get;set;}
        public int Priority {get;set;}
    }
}