using System;
using System.Collections.Generic;

namespace University.Cources.Core.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public decimal Budget { get; set; }
        
        public DateTime StartDate { get; set; }

        public int? InstructorId { get; set; }
        
        public Instructor Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}