using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.Types;

namespace University.Cources.Application.Services
{
    public interface IEventProcessor
    {
        Task ProcessAsync(IEnumerable<IDomainEvent> events);
    }
}