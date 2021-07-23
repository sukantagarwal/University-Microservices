using System;
using MicroPack.Types;

namespace University.Students.Core.Entities
{
    public class OfficeAssignment: BaseAggregateRoot<OfficeAssignment, Guid>
    {
        public Guid InstructorId { get; set; }
        public string Location { get; set; }
    }
}