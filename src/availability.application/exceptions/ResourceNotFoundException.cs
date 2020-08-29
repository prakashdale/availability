using System;

namespace availability.application.exceptions
{
    public class ResourceNotFoundException : AppException
    {
        public override string Code { get; } = "resource_not_found";
        public Guid Id { get; }

        public ResourceNotFoundException(Guid id) : base($"Resource with id: {id} was not found.")
            => Id = id;
    }
}