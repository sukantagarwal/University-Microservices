using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MicroPack.Types;
using University.Students.Core.Events;

namespace University.Students.Core.Entities
{
    public class Student: BaseAggregateRoot<Student, Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FullName => LastName + ", " + FirstName;
        
        private readonly List<Enrollment> _enrollments = new List<Enrollment>();
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.ToImmutableArray();
        
        private Student(Guid id, string firstName, string lastName, DateTime enrollmentDate): base(id)
        {
             Id = id;
             FirstName = firstName;
             LastName = lastName;
             EnrollmentDate = enrollmentDate;
             AddEvent(new StudentCreatedDomainEvent(this));
        }

        public static Student Create(string firstName, string lastName, DateTime enrollmentDate)
        {
          //  CheckRule(new StudentMustBeUniqueRule(firstName, lastName, studentUniquenessChecker));
            var student = new Student(Guid.NewGuid() , firstName, lastName, enrollmentDate);
            return student;
        }
    }
}