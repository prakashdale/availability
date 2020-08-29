namespace availability.core.exceptions
{
    public class MissingResourceTagsException : DomainException
    {
        public override string Code { get; } = "missing_resource_tags";
        
        public MissingResourceTagsException() : base("Resource tags are missing.")
        {
        }
    }
}