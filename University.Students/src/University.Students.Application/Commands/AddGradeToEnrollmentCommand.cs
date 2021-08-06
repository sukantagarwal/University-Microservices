using System;
using BuildingBlocks.CQRS.Commands;
using University.Students.Core.Entities;

namespace University.Students.Application.Commands
{
    public class AddGradeToEnrollmentCommand : ICommand
    {
        public Guid EnrollmentId { get;}
        public Grade Grade { get;}

        public AddGradeToEnrollmentCommand(Guid enrollmentId, Grade grade)
        {
            EnrollmentId = enrollmentId;
            Grade = grade;
        }
    }
}