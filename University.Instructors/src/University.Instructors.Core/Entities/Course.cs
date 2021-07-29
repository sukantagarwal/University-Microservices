using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MicroPack.Types;

namespace University.Instructors.Core.Entities
{
    public class Course: BaseAggregateRoot<Course, Guid>
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public Guid DepartmentId { get; set; }
        
        [NotMapped]
        public IReadOnlyCollection<Enrollment> Enrollments { get; set; }
        [NotMapped]
        public IReadOnlyCollection<CourseAssignment> CourseAssignments { get; set; }
    }
}