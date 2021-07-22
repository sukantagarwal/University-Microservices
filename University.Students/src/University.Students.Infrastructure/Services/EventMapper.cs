using System.Collections.Generic;
using System.Linq;
using MicroPack.CQRS.Events;
using MicroPack.Types;
using University.Students.Application.Events;
using University.Students.Application.Services;
using University.Students.Core.Events;

namespace University.Students.Infrastructure.Services
{
    internal sealed class EventMapper : IEventMapper
    {
        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
            => events.Select(Map);

        public IEvent Map(IDomainEvent @event)
            => @event switch
            {
                StudentCreatedDomainEvent e => new StudentCreated(e.Id),
                _ => null
            };
    }
}