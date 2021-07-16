using System;
using MicroPack.Types;

namespace University.Students.Core.Entities
{
    public class Enrollment: BaseAggregateRoot<Enrollment, Guid>
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public Grade? Grade { get; set; }
        // protected override void Apply(IDomainEvent<Guid> @event)
        // {
        //     throw new NotImplementedException();
        // }
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