using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Metrics.AspNetCore;
using MicroPack;
using MicroPack.Authentication;
using MicroPack.Logging;
using MicroPack.MessageBrokers.RabbitMQ;
using MicroPack.Security;
using MicroPack.Tracing.Jaeger;
using MicroPack.Vault;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Pacco.APIGateway.Ocelot.Infrastructure;
using Extensions = MicroPack.Extensions;

namespace University.ApiGateway.Ocelot
{
    public class Program
    {
         public static Task Main(string[] args) => CreateHostBuilder(args).Build().RunAsync();

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", false)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                        .AddJsonFile("ocelot.json")
                        .AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(builder => builder
                    .ConfigureServices(services =>
                    {
                        services.AddMetrics();
                        services.AddHttpClient();
                        services.AddSingleton<IPayloadBuilder, PayloadBuilder>();
                        services.AddSingleton<ICorrelationContextBuilder, CorrelationContextBuilder>();
                        services.AddSingleton<IAnonymousRouteValidator, AnonymousRouteValidator>();
                        services.AddTransient<AsyncRoutesMiddleware>();
                        services.AddTransient<ResourceIdGeneratorMiddleware>();
                        services.AddOcelot()
                            .AddDelegatingHandler<CorrelationContextHandler>(true);

                        Extensions.AddMicroPack(services)
                            .AddErrorHandler<ExceptionToResponseMapper>()
                            .AddJaeger()
                            .AddJwt()
                            .AddRabbitMq()
                            .AddSecurity();

                        using var provider = services.BuildServiceProvider();
                        var configuration = provider.GetService<IConfiguration>();
                        services.Configure<AsyncRoutesOptions>(configuration.GetSection("AsyncRoutes"));
                        services.Configure<AnonymousRoutesOptions>(configuration.GetSection("AnonymousRoutes"));
                    })
                    .Configure(app =>
                    {
                        app.UseErrorHandler();
                        app.UseAccessTokenValidator();
                        app.UseAuthentication();
                        app.UseRabbitMq();
                      
                        app.UseMiddleware<AsyncRoutesMiddleware>();
                        app.UseMiddleware<ResourceIdGeneratorMiddleware>();
                        app.UseOcelot();
                    })
                    .UseLogging()
                    .UseVault()
                    .UseMetrics());
        
    }
}
