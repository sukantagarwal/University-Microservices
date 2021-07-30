using System;
using MicroPack.Types;

namespace University.Departments.Core.Events
{
    public class AdministratorAssignedDomainEvent: IDomainEvent
    {
        public Guid InstructorId { get; }
        public Guid DepartmentId { get; }

        public AdministratorAssignedDomainEvent(Guid instructorId, Guid departmentId)
        {
            InstructorId = instructorId;
            DepartmentId = departmentId;
        }
    }
}