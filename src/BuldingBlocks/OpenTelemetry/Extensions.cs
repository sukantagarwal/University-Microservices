using System;
using DotNetCore.CAP.Transport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace BuildingBlocks.OpenTelemetry
{
    public static class Extensions
    {
        public static IServiceCollection AddOpenTelemetry(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            var exporter = configuration.GetValue<string>("UseExporter").ToLowerInvariant();
            switch (exporter)
            {
                case "jaeger":
                    services.AddOpenTelemetryTracing(builder => builder
                        .SetResourceBuilder(ResourceBuilder.CreateDefault()
                            .AddService(configuration.GetValue<string>("Jaeger:ServiceName")))
                        .AddAspNetCoreInstrumentation()
                        .AddSource(nameof(ITransport))
                        .AddJaegerExporter());
                    break;
                case "zipkin":
                    services.AddOpenTelemetryTracing(builder => builder
                        .SetResourceBuilder(ResourceBuilder.CreateDefault()
                            .AddService(configuration.GetValue<string>("zipkin:ServiceName")))
                        .AddAspNetCoreInstrumentation()
                        .AddSource(nameof(ITransport))
                        .AddZipkinExporter(zipkinOptions =>
                        {
                            zipkinOptions.Endpoint = new Uri(configuration.GetValue<string>("Zipkin:Endpoint"));
                        }));
                    break;
                default:
                    services.AddOpenTelemetryTracing(builder => builder
                        .AddAspNetCoreInstrumentation()
                        .AddConsoleExporter());
                    break;
            }

            return services;
        }
    }
}