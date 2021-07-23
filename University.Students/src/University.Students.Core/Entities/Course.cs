using System;
using System.Collections.Generic;
using MicroPack.Types;

namespace University.Students.Core.Entities
{
    public class Course: BaseAggregateRoot<Course, Guid>
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public Guid DepartmentId { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}