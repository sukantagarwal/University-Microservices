using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MicroPack.Types;
using University.Students.Core.Events;
using University.Students.Core.ValueObjects;

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
             
            AddEvent(new StudentCreatedDomainEvent(Id));
        }

        public static Student Create(string firstName, string lastName, DateTime enrollmentDate)
        {
          //  CheckRule(new StudentMustBeUniqueRule(firstName, lastName, studentUniquenessChecker));
            return new Student(Guid.NewGuid() , firstName, lastName, enrollmentDate);
        }
        public void Edit(string firstName, string lastName, DateTime enrollmentDate)
        {
            // _personName = new PersonName(firstName, lastName);
            // _enrollmentDate = enrollmentDate;
            //
            // AddEvent(new StudentEditedDomainEvent(Id,_personName.First,_personName.Last,enrollmentDate));
        }
        
        
        // public void EnrollToCourse(Guid courseId)
        // {
        //     //CheckRule(new CannotEnrollStudentTwiceToTheSameCourseRule(Id, courseId, _enrollments));          
        //     _enrollments.Add(Enrollment.CreateNew(Id, courseId));
        // }
        // public void AddGrade(Guid courseId,Grade grade)
        // {
        //     //CheckRule(new CannotAddGradeToUnenrolledStudentRule(Id, courseId, _enrollments));
        //    // CheckRule(new CannotChangeGradeRule(Id, courseId, _enrollments));
        //     _enrollments.SingleOrDefault(e => e.CourseId == courseId && e.StudentId == Id).AddGrade(grade);
        // }
        // public void SoftDelete()
        // {
        //     _isDeleted = true;
        //     foreach (var enrollment in _enrollments)
        //     {
        //         enrollment.SoftDelete();
        //     }
        // // }
        //
        // protected override void Apply(IDomainEvent<Guid> @event)
        // {
        //     throw new NotImplementedException();
        // }
    }
}