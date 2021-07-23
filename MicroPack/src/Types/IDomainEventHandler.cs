using System.Threading.Tasks;

namespace MicroPack.Types
{
    public interface IDomainEventHandler<in T> where T : class
    {
        Task HandleAsync(T @event);
    }
}