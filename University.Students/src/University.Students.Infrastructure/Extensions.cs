using System.Text.Encodings.Web;
using System.Text.Unicode;
using BuildingBlocks;
using BuildingBlocks.Exception;
using BuildingBlocks.OpenTelemetry;
using BuildingBlocks.Types;
using DotNetCore.CAP.Messages;
using DotNetCore.CAP.Transport;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using University.Students.Application;
using University.Students.Application.Services;
using University.Students.Infrastructure.EfCore;
using University.Students.Infrastructure.Services;

namespace University.Students.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration!.GetSection("ConnectionString").Value;

            var outboxOptions = services.GetOptions<Options.OutboxOptions>("Outbox");
            services.AddSingleton(outboxOptions);

            var rabbitMqOptions = services.GetOptions<Options.RabbitMqOptions>("RabbitMq");
            services.AddSingleton(rabbitMqOptions);

            services.AddErrorHandler<ExceptionToResponseMapper>();
            services.AddTransient<IExceptionToMessageMapper, ExceptionToMessageMapper>();

            services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IStudentDbContext>(provider => provider.GetService<StudentDbContext>());

            services.AddDbContext<StudentDbContext>();

            services.AddTransient<IMessageBroker, MessageBroker>();
            services.AddTransient<IEventMapper, EventMapper>();
            services.AddTransient<IEventProcessor, EventProcessor>();
            
            services.AddCap(x =>
            {
                x.UseEntityFramework<StudentDbContext>();

                x.UseSqlServer(connectionString);

                x.UseRabbitMQ(r =>
                {
                    r.HostName = rabbitMqOptions.HostName;
                    r.ExchangeName = rabbitMqOptions.ExchangeName;
                });

                x.FailedRetryCount = 5;
                x.FailedThresholdCallback = failed =>
                {
                    Log.Error(
                        $@"A message of type {failed.MessageType} failed after executing {x.FailedRetryCount} several times, 
                        requiring manual troubleshooting. Message name: {failed.Message.GetName()}");
                };
                x.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });

            services.AddOpenTelemetry();
            
            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler();
            return app;
        }
    }
}