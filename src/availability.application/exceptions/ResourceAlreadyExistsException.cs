using System;

namespace availability.application.exceptions {
    public class ResourceAlreadyExistsException : AppException
    {
        public ResourceAlreadyExistsException(Guid id) : base($"Resource with id: '{id}' already exists")
        {
        }
    }

    

}