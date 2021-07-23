using System;
using System.ComponentModel.DataAnnotations.Schema;
using MicroPack.Types;

namespace University.Departments.Core.Entities
{
    public class CourseAssignment: BaseAggregateRoot<CourseAssignment, Guid>
    {
        public Guid InstructorId { get; set; }
        public Guid CourseId { get; set; }
    }
}