using System.Threading;
using System.Threading.Tasks;
using MicroPack.CQRS.Commands;
using University.Students.Application.Services;
using University.Students.Core.Entities;

namespace University.Students.Application.Commands.Handlers
{
    public class AddStudentHandler : ICommandHandler<AddStudent>
    {
        private readonly IEventProcessor _eventProcessor;
        private readonly IStudentDbContext _studentDbContext;

        public AddStudentHandler(IEventProcessor eventProcessor, IStudentDbContext studentDbContext)
        {
            _eventProcessor = eventProcessor;
            _studentDbContext = studentDbContext;
        }

        public async Task HandleAsync(AddStudent command, CancellationToken token)
        {
            var student = Student.Create(command.FirstName, command.LastName, command.EnrollmentDate!.Value);
            await _studentDbContext.Students.AddAsync(student, token);

            await _eventProcessor.ProcessAsync(student.Events);

            await _studentDbContext.CommitTransactionAsync(token);
        }
    }
}