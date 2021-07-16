using System.Threading.Tasks;
using EventStore.ClientAPI;

namespace MicroPack.EventStore
{
    public interface IEventStoreConnectionWrapper
    {
        Task<IEventStoreConnection> GetConnectionAsync();
    }
}