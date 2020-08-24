using System;
using availability.core.repositories;
using availability.infrastructure.exceptions;
using availability.infrastructure.mongo.documents;
using availability.infrastructure.mongo.repositories;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace availability.infrastructure.mongo {
    public static class Extensions {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder){
            builder.Services.AddTransient<IResourceRepository, ResourcesMongoRepository>();
            

            builder
            .AddErrorHandler<ExceptionResponseMapper>()
            .AddQueryHandlers()
            .AddInMemoryQueryDispatcher()
            .AddMongo()
            .AddMongoRepository<ResourceDocument, Guid>("resources");

            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app){
            app
                .UseErrorHandler()
                .UseConvey();
                

            return app;

        }
        
    }
}