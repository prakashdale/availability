using System;

namespace availability.core.exceptions {
    public class InvalidResourceTagsException : DomainException
    {
        public InvalidResourceTagsException() : base("Missing Resource tag")
        {
        }
    }
}
