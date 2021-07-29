using MicroPack;
using MicroPack.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.Departments.Application;
using University.Departments.Application.Services;
using University.Departments.Infrastructure.EfCore;
using University.Departments.Infrastructure.Services;

namespace University.Departments.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration!.GetSection("connectionString").Value;

            services.AddDbContext<DepartmentDbContext>(options =>
                options.UseSqlServer(connectionString));
            
            
            var outboxOptions = services.GetOptions<OutboxOptions>("outbox");
            services.AddSingleton(outboxOptions);
            
            services.AddTransient<IDepartmentDbContext>(provider => provider.GetService<DepartmentDbContext>());
            
            services.AddDbContext<DepartmentDbContext>();
            
            services.AddTransient<IMessageBroker, MessageBroker>();
            services.AddTransient<IEventMapper, EventMapper>();
            services.AddTransient<IEventProcessor, EventProcessor>();
            
            services.AddCap(x =>
            {
                x.UseEntityFramework<DepartmentDbContext>(); 
            
                x.UseSqlServer(connectionString);
            
                x.UseRabbitMQ( r=>
                {
                    r.HostName = "localhost";
                    r.ExchangeName = "departments";
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