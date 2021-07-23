using System;
using System.Collections.Generic;

namespace University.Cources.Core.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }
        public string FullName => LastName + ", " + FirstMidName;

        public ICollection<CourseAssignment> CourseAssignments { get; private set; } = new List<CourseAssignment>();
        public OfficeAssignment OfficeAssignment { get; private set; }
    }
}