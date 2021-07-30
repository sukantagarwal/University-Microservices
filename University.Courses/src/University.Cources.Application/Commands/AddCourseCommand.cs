using System;
using MicroPack.CQRS.Commands;
using University.Cources.Core.Entities;

namespace University.Cources.Application.Commands
{
    public class AddCourseCommand: ICommand
    {
        public string Title { get; init; }
        public int Credits { get; init; }
        public Guid DepartmentId { get; init; }
    }
}