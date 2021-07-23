using System.Collections.Generic;
using System.Threading.Tasks;
using MicroPack.CQRS.Events;

namespace University.Departments.Application.Services
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IEvent[] events);
        Task PublishAsync(IEnumerable<IEvent> events);
    }
}