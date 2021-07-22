using System;
using System.Collections.Generic;
using DotNetCore.CAP;
using DotNetCore.CAP.Internal;
using MicroPack;
using MicroPack.CQRS.Commands;
using MicroPack.CQRS.Events;
using MicroPack.EventStore;
using MicroPack.Http;
using MicroPack.MessageBrokers.CQRS;
using MicroPack.MessageBrokers.Outbox;
using MicroPack.MessageBrokers.Outbox.Mongo;
using MicroPack.MessageBrokers.RabbitMQ;
using MicroPack.Metrics.AppMetrics;
using MicroPack.Mongo;
using MicroPack.Security;
using MicroPack.Tracing.Jaeger;
using MicroPack.Types;
using MicroPack.WebApi;
using MicroPack.WebApi.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.Students.Application;
using University.Students.Application.Commands;
using University.Students.Application.Services;
using University.Students.Infrastructure.EfCore;
using University.Students.Infrastructure.Services;
using OutboxOptions = MicroPack.Types.OutboxOptions;

namespace University.Students.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration!.GetSection("connectionString").Value;

            services.AddTransient<IMessageBroker, MessageBroker>();
            services.AddTransient<IEventMapper, EventMapper>();
            services.AddTransient<IEventProcessor, EventProcessor>();

            // services.AddDbContext<StudentDbContext>(options =>
            //     options.UseSqlServer(connectionString));
            //
            services.AddTransient<IStudentDbContext>(provider => provider.GetService<StudentDbContext>());
            
            services.AddDbContext<StudentDbContext>();
            
            services.AddCap(x =>
            {
                x.UseEntityFramework<StudentDbContext>(); 

                x.UseSqlServer(connectionString);

                x.UseRabbitMQ("localhost");

                x.FailedRetryCount = 5;
            });
            
            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            //app.UseInitializers();
            //  .UseErrorHandler();
            //app.UseRabbitMq().SubscribeCommand<AddStudent>();

            return app;
        }
    }
}