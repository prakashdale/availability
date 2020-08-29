using availability.application;

namespace availability.infrastructure.contexts
{
    internal interface IAppContextFactory
    {
        IAppContext Create();
    }
}