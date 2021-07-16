using System;
using MicroPack.Types;

namespace University.Students.Core.Events
{
    public class StudentEditedDomainEvent : IDomainEvent<Guid>
    {
        public Guid StudentId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime EnrollmentDate { get; }

        public StudentEditedDomainEvent(Guid studentId, string firstName, string lastName,DateTime enrollmentDate)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            EnrollmentDate = enrollmentDate;
        }

        public long AggregateVersion { get; }
        public Guid AggregateId { get; }
        public DateTime Timestamp { get; }
    }
}
