using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MicroPack.Types;

namespace University.Instructors.Core.Entities
{
    public class Department: BaseAggregateRoot<Department, Guid>
    {
        public string Name { get; set; }
        
        public decimal Budget { get; set; }
        
        public DateTime StartDate { get; set; }

        public Guid? InstructorId { get; set; }
        
        private readonly List<Course> _courses = new List<Course>();
        public IReadOnlyCollection<Course> Courses => _courses.ToImmutableArray();
        
    }
}