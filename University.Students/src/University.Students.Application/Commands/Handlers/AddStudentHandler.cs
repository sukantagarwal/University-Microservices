using System.Threading;
using System.Threading.Tasks;
using MicroPack.CQRS.Commands;
using University.Students.Core.Entities;

namespace University.Students.Application.Commands.Handlers
{
    public class AddStudentHandler : ICommandHandler<AddStudent>
    {
        private readonly IStudentDbContext _studentDbContext;

        public AddStudentHandler(IStudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public async Task HandleAsync(AddStudent command, CancellationToken token)
        {
            var student = Student.Create(command.FirstName, command.LastName, command.EnrollmentDate!.Value);
            await _studentDbContext.Students.AddAsync(student, token);

            //  await _eventProcessor.ProcessAsync(resource.Events);

            await _studentDbContext.CommitTransactionAsync(token);
        }
    }
}