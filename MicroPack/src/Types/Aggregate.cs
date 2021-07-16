using System;
using System.Collections.Generic;

namespace MicroPack.Types
{
    public abstract class Aggregate
    {
        readonly List<IDomainEvent> _events = new List<IDomainEvent>();

        public Guid Id { get; protected set; } = Guid.Empty;
        public long Version { get; protected set; } = -1;

        protected abstract void Apply(object @event);

        public void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
            this.Version++;
            Apply(@event);
        }

        public void Load(long version, IEnumerable<object> history)
        {
            Version = version;

            foreach (var e in history)
            {
                Apply(e);
            }
        }

        public IEnumerable<IDomainEvent> Events => _events;
    }
}