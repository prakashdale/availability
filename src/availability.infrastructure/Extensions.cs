using System;
using availability.application;
using availability.application.events.external;
using availability.application.services;
using availability.core.repositories;
using availability.infrastructure.exceptions;
using availability.infrastructure.mongo.documents;
using availability.infrastructure.mongo.repositories;
using availability.infrastructure.services;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace availability.infrastructure {
    public static class Extensions {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder){
            builder.Services.AddTransient<IResourceRepository, ResourcesMongoRepository>();
            builder.Services.AddTransient<IMessageBroker, MessageBroker>();
            builder.Services.AddTransient<IEventMapper, EventMapper>();
            builder.Services.AddTransient<IEventProcessor, EventProcessor>();
            

            builder
            .AddErrorHandler<ExceptionToResponseMapper>()
            .AddQueryHandlers()
            .AddInMemoryQueryDispatcher()
            .AddMongo()
            .AddMongoRepository<ResourceDocument, Guid>("resources")
            .AddRabbitMq()
            .AddExceptionToMessageMapper<ExceptionToMessageMapper>();

            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app){
            app
                .UseErrorHandler()
                .UseConvey()
                .UsePublicContracts<ContractAttribute>()
                .UseRabbitMq()
                .SubscribeEvent<SignedUp>();
                

            return app;

        }
        
    }
}