using Convey;
using Convey.Logging.CQRS;
using Microsoft.Extensions.DependencyInjection;
using availability.application.commands;

namespace availability.infrastructure.logging
{
    internal static class Extensions
    {
        public static IConveyBuilder AddHandlersLogging(this IConveyBuilder builder)
        {
            var assembly = typeof(AddResource).Assembly;
            
            builder.Services.AddSingleton<IMessageToLogTemplateMapper>(new MessageToLogTemplateMapper());
            
            return builder
                .AddCommandHandlersLogging(assembly)
                .AddEventHandlersLogging(assembly);
        }
    }
}