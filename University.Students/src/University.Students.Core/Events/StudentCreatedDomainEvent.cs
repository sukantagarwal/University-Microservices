using System;
using MicroPack.Types;

namespace University.Students.Core.Events
{
    public class StudentCreatedDomainEvent : IDomainEvent<Guid>
    {
        public Guid StudentId { get; }
        public StudentCreatedDomainEvent(Guid studentId)
        {
            StudentId = studentId;
        }

        public long AggregateVersion { get; }
        public Guid AggregateId { get; }
        public DateTime Timestamp { get; }
    }
}