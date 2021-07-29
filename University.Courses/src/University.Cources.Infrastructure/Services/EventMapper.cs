using System.Collections.Generic;
using System.Linq;
using MicroPack.CQRS.Events;
using MicroPack.Types;
using University.Cources.Application.Events;
using University.Cources.Application.Services;
using University.Cources.Core.Events;

namespace University.Cources.Infrastructure.Services
{
    internal sealed class EventMapper : IEventMapper
    {
        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
            => events.Select(Map);

        public IEvent Map(IDomainEvent @event)
            => @event switch
            {
                CourseCreatedDomainEvent e => new CourseCreated(e.Id),
                _ => null
            };
    }
}