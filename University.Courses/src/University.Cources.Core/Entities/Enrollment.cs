using System;
using MicroPack.Types;

namespace University.Cources.Core.Entities
{
    public class Enrollment: BaseAggregateRoot<Enrollment, Guid>
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
    }
    
    public enum Grade
    {
        A, B, C, D, F
    }
}