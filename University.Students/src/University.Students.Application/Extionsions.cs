using MicroPack.CQRS.Commands;
using MicroPack.CQRS.Events;
using MicroPack.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace University.Students.Application
{
    public static class Extionsions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<StudentCreatedConsumer>();
            return services
                .AddCommandHandlers()
                .AddEventHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryEventDispatcher()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher();
        }
    }
}