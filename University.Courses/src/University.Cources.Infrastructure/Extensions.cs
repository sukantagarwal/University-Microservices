using MicroPack;
using MicroPack.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.Cources.Application.Services;
using University.Cources.Infrastructure.EfCore;
using University.Cources.Infrastructure.Services;

namespace University.Cources.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration!.GetSection("connectionString").Value;

            services.AddDbContext<CourseDbContext>(options =>
                options.UseSqlServer(connectionString));
            
            
            var outboxOptions = services.GetOptions<OutboxOptions>("outbox");
            services.AddSingleton(outboxOptions);
            
            services.AddTransient<CourseDbContext>(provider => provider.GetService<CourseDbContext>());
            
            services.AddDbContext<CourseDbContext>();
            
            services.AddTransient<IMessageBroker, MessageBroker>();
            services.AddTransient<IEventMapper, EventMapper>();
            services.AddTransient<IEventProcessor, EventProcessor>();
            
            services.AddCap(x =>
            {
                x.UseEntityFramework<CourseDbContext>(); 
            
                x.UseSqlServer(connectionString);
            
                x.UseRabbitMQ( r=>
                {
                    r.HostName = "localhost";
                    r.ExchangeName = "courses";
                });
            
                x.FailedRetryCount = 5;
            });
            
            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            return app;
        }
    }
}