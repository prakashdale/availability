namespace availability.application
{
    public interface IAppContext
    {
        string RequestId { get; }
        IIdentityContext Identity { get; }
    }
}