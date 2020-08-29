using System;

namespace availability.application.exceptions {
    public class ResourceAlreadyExistsException : AppException
    {
        public Guid Id {get;}
        public ResourceAlreadyExistsException(Guid id) : base($"Resource with id: '{id}' already exists")
        {
            Id = id;
        }
    }

    

}