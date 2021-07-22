using System.Collections.Generic;
using System.Threading.Tasks;
using MicroPack.Types;

namespace University.Students.Application.Services
{
    public interface IEventProcessor
    {
        Task ProcessAsync(IEnumerable<IDomainEvent> events);
    }
}