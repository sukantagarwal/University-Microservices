using System.Threading.Tasks;

namespace MicroPack
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}