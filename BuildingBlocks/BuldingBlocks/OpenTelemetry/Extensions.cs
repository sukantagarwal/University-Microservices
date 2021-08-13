using System;
using BuildingBlocks.OpenTelemetry.Messaging;
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
            services.AddSingleton<RabbitMqHelper>();
            services.AddSingleton<MessageSender>();
            services.AddSingleton<MessageReceiver>();
            services.AddHostedService<Worker>();

            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            var exporter = configuration.GetValue<string>("UseExporter").ToLowerInvariant();
            switch (exporter)
            {
                case "jaeger":
                    services.AddOpenTelemetryTracing(builder => builder
                        .SetResourceBuilder(ResourceBuilder.CreateDefault()
                            .AddService(configuration.GetValue<string>("Jaeger:ServiceName")))
                        .AddAspNetCoreInstrumentation()
                        .AddJaegerExporter(jaegerOptions =>
                        {
                            jaegerOptions.AgentHost = configuration.GetValue<string>("Jaeger:Host");
                            jaegerOptions.AgentPort = configuration.GetValue<int>("Jaeger:Port");
                        }));
                    break;
                case "zipkin":
                    services.AddOpenTelemetryTracing(builder => builder
                        .AddAspNetCoreInstrumentation()
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