using System.Collections.Generic;

namespace BuildingBlocks.Types
{
    public interface IAggregateRoot<out TKey> : IIdentifiable<TKey>
    {
        //   long Version { get; }
        IEnumerable<IDomainEvent> Events { get; }
        void ClearEvents();
    }
}