using System;
using MicroPack.Types;

namespace University.Instructors.Core.Entities
{
    public class CourseAssignment: BaseAggregateRoot<CourseAssignment, Guid>
    {
        public Guid InstructorId { get; set; }
        public Guid CourseId { get; set; }
    }
}