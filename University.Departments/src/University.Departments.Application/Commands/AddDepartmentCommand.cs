using System;
using MicroPack.CQRS.Commands;
using University.Departments.Core.Entities;

namespace University.Departments.Application.Commands
{
    public class AddDepartmentCommand: ICommand
    {
        public string Name { get; init; }
        public decimal Budget { get; init; }
        public DateTime StartDate { get; init; }
        public Guid? AdministratorId { get; init; }
    }
}