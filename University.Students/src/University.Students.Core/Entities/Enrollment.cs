using System;
using BuildingBlocks.Types;
using University.Students.Core.Events;

namespace University.Students.Core.Entities
{
    public class Enrollment: BaseAggregateRoot<Enrollment, Guid>
    {
        public Guid CourseId { get; private set; }
        public Guid StudentId { get; private set; }
        public Grade? Grade { get; private set; }
        
        private Enrollment(Guid id, Guid studentId, Guid courseId)
        {
            Id = id;
            StudentId = studentId;
            CourseId = courseId;

            AddEvent(new EnrollmentCreatedDomainEvent(this));
        }
        
        public static Enrollment CreateNew(Guid studentId, Guid courseId)
        {
            return new Enrollment(Guid.NewGuid(), studentId,courseId);
        }

        public void AddGrade(Grade grade)
        {
            Grade = grade;
        }
    }
    
    public enum Grade
    {
        A,
        B,
        C,
        D,
        F
    }
    
}