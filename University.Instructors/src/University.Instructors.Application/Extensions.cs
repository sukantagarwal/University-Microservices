using MicroPack.CQRS.Commands;
using MicroPack.CQRS.Events;
using MicroPack.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace University.Instructors.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
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