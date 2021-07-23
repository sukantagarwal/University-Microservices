using System;
using MicroPack.Types;

namespace University.Departments.Core.Entities
{
    public class Enrollment: BaseAggregateRoot<Enrollment, Guid>
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public Grade? Grade { get; set; }
    }
    
    public enum Grade
    {
        A,
        B,
        C,
        D,
        F
    }
}