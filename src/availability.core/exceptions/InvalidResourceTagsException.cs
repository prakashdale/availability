namespace availability.core.exceptions
{
    public class InvalidResourceTagsException : DomainException
    {
        public override string Code { get; } = "invalid_resource_tags";
        
        public InvalidResourceTagsException() : base("Resource tags are invalid.")
        {
        }
    }
}