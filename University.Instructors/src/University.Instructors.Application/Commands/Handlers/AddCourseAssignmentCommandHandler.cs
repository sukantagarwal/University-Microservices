using System;
using System.Threading;
using System.Threading.Tasks;
using MicroPack.CQRS.Commands;
using University.Instructors.Application.Services;
using University.Instructors.Core.Entities;

namespace University.Instructors.Application.Commands.Handlers
{
    public class AddCourseAssignmentCommandHandler: ICommandHandler<AddCourseAssignmentCommand>
    {
        private readonly IInstructorDbContext _instructorDbContext;
        private readonly IEventProcessor _eventProcessor;

        public AddCourseAssignmentCommandHandler(IInstructorDbContext instructorDbContext, IEventProcessor eventProcessor)
        {
            _instructorDbContext = instructorDbContext;
            _eventProcessor = eventProcessor;
        }
        public async Task HandleAsync(AddCourseAssignmentCommand command, CancellationToken token)
        {
            var courseAssignment = CourseAssignment.CreateNew(command.InstructorId, command.CourseId);
            
            await _instructorDbContext.CourseAssignments.AddAsync(courseAssignment, token);

            await _eventProcessor.ProcessAsync(courseAssignment.Events);

            await _instructorDbContext.CommitTransactionAsync(token);
        }
    }
}