using System;

namespace availability.core.exceptions {
    public class InvalidAggregateIdException : DomainException
    {
        public Guid Id {get;}

        public InvalidAggregateIdException(Guid id) : base($"Invalid Aggregate Id: '{id.ToString()}'")
        {
            Id = id;
        }
    }
}
