using System.Collections.Generic;
using MicroPack.CQRS.Events;
using MicroPack.Types;

namespace University.Instructors.Application.Services
{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
    }
}