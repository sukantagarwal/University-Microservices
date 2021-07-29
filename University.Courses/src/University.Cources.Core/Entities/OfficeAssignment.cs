using System;
using MicroPack.Types;

namespace University.Cources.Core.Entities
{
    public class OfficeAssignment: BaseAggregateRoot<OfficeAssignment, Guid>
    {
        public int InstructorId { get; set; }
        public string Location { get; set; }
    }
}