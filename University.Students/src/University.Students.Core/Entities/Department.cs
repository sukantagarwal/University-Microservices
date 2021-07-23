using System;
using System.Collections.Generic;
using MicroPack.Types;

namespace University.Students.Core.Entities
{
    public class Department: BaseAggregateRoot<Department, Guid>
    {
        public string Name { get; set; }
        
        public decimal Budget { get; set; }
        
        public DateTime StartDate { get; set; }

        public Guid? InstructorId { get; set; }
        public ICollection<Course> Courses { get; set; }
        
    }
}