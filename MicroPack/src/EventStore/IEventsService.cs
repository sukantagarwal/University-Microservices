using System.Threading.Tasks;
using MicroPack.Types;

namespace MicroPack.EventStore
{
    public interface IEventsService<TA, TKey> 
        where TA : class, IAggregateRoot<TKey>
    {
        Task SaveAsync(TA aggregateRoot);
        Task<TA> GetByIdAsync(TKey key);
    }
}