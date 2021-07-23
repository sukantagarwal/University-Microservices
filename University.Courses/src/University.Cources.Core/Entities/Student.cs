using System;
using System.Collections.Generic;

namespace University.Cources.Core.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
     
        public DateTime EnrollmentDate { get; set; }
        public string FullName => LastName + ", " + FirstMidName;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}