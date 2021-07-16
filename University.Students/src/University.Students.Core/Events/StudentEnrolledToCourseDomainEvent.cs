using System;
using MicroPack.Types;

namespace University.Students.Core.Events
{
    public class StudentEnrolledToCourseDomainEvent : IDomainEvent<Guid>
    {
        public Guid StudentId { get; }
        public Guid CourseId { get; }
        public StudentEnrolledToCourseDomainEvent(Guid studentId, Guid courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }

        public long AggregateVersion { get; }
        public Guid AggregateId { get; }
        public DateTime Timestamp { get; }
    }
}