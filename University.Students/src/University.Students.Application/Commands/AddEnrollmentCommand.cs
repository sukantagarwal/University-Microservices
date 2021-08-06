using System;
using BuildingBlocks.CQRS.Commands;
using University.Students.Core.Entities;

namespace University.Students.Application.Commands
{
    public class AddEnrollmentCommand: ICommand
    {
        public Guid CourseId { get;}
        public Guid StudentId { get;}

        public AddEnrollmentCommand(Guid courseId, Guid studentId)
        {
            CourseId = courseId;
            StudentId = studentId;
        }
    }
}