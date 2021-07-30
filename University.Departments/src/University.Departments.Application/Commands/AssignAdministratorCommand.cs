using System;
using MicroPack.CQRS.Commands;

namespace University.Departments.Application.Commands
{
    public class AssignAdministratorCommand: ICommand
    {
        public Guid DepartmentId { get; init; }
        public Guid InstructorId { get; init; }
    }
}