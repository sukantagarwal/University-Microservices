using System;
using System.Collections.Generic;
using MicroPack.Types;

namespace University.Departments.Core.Entities
{
    public class Student: BaseAggregateRoot<Student, Guid>
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
     
        public DateTime EnrollmentDate { get; set; }
        public string FullName => LastName + ", " + FirstMidName;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}