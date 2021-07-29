using System;
using MicroPack.Types;

namespace University.Cources.Core.Entities
{
    public class CourseAssignment: BaseAggregateRoot<CourseAssignment, Guid>
    {
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
    }
}