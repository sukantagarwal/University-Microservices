using System;
using MicroPack.Types;

namespace University.Students.Core.Entities
{
    public class CourseAssignment: BaseAggregateRoot<CourseAssignment, Guid>
    {
        public Guid InstructorId { get; set; }
        public Guid CourseId { get; set; }
    }
}