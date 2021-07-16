using System;
using MicroPack;
using MicroPack.Consul;
using MicroPack.CQRS.Commands;
using MicroPack.CQRS.Events;
using MicroPack.EventStore;
using MicroPack.Http;
using MicroPack.MessageBrokers.CQRS;
using MicroPack.MessageBrokers.Outbox;
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
using University.Students.Infrastructure.EfCore;

namespace University.Students.Infrastructure
{
    public static class Extensions
    {
            public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddRabbitMq();
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration!.GetSection("connectionString").Value;
            
            services.AddDbContext<StudentDbContext>(options =>
                options.UseSqlServer(connectionString));
            
            services.AddTransient<IStudentDbContext>(provider => provider.GetService<StudentDbContext>());
            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseInitializers();
              //  .UseErrorHandler();
            app.UseRabbitMq().SubscribeCommand<AddStudent>();

            return app;
        }
    }
}