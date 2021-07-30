using System;
using MicroPack.CQRS.Commands;

namespace University.Students.Application.Commands
{
    [Contract]
    public class AddStudentCommand : ICommand
    {
        public string LastName { get; init; }

        public string FirstName { get; init; }

        public DateTime? EnrollmentDate { get; init; }
    }
}