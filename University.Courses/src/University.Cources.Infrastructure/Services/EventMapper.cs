using BuildingBlocks.CQRS.Events;
using BuildingBlocks.Types;
using University.Cources.Application.Events;
using University.Cources.Application.Services;
using University.Cources.Core.Events;

namespace University.Cources.Infrastructure.Services
{
    internal sealed class EventMapper : IEventMapper
    {
        public IEvent Map(IDomainEvent @event)
        {
            return @event switch
            {
                CourseCreatedDomainEvent e => new CourseCreated(e.Id),
                _ => null
            };
        }
    }
}