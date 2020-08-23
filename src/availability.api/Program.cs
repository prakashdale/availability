using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Convey;
using availability.application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using availability.infrastructure.mongo;

namespace availability.api
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await CreateWebHostBuilder(args)
                .Build()
                .RunAsync();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => {
                    services.AddControllers().AddNewtonsoftJson();
                    services
                    .AddConvey()
                    .AddApplication()
                    .AddInfrastructure()
                    .Build();
                })
                .Configure(app => {
                    app.UseInfrastructure();
                    app.UseRouting()
                       .UseEndpoints(x => x.MapControllers()) ;
                });
    }
}