using System;
using System.Collections.Generic;
using System.Linq;
using MicroPack.CQRS.Commands;

namespace University.Students.Application.Commands
{
    [Contract]
    public class AddStudent : ICommand
    {
        public string LastName { get; init; }

        public string FirstName { get; init; }

        public DateTime? EnrollmentDate { get; init; }
    }
}