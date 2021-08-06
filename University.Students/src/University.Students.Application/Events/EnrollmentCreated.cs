using System;
using BuildingBlocks.CQRS.Events;

namespace University.Students.Application.Events
{
    public class EnrollmentCreated: IEvent
    {
        public Guid Id { get; }
        public Guid StudentId { get; }
        public Guid CourseId { get; }

        public EnrollmentCreated(Guid id, Guid studentId, Guid courseId)
        {
            Id = id;
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}