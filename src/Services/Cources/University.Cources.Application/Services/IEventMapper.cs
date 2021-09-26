using BuildingBlocks.CQRS.Events;
using BuildingBlocks.Types;

namespace University.Cources.Application.Services
{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);
    }
}