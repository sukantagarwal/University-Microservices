using System.Threading;
using System.Threading.Tasks;
using MicroPack.CQRS.Commands;
using University.Instructors.Application.Services;

namespace University.Instructors.Application.Commands.Handlers
{
    public class AddDepartmentHandler: ICommandHandler<AddDepartment>
    {
       

        public AddDepartmentHandler()
        {
           
        }

        public async Task HandleAsync(AddDepartment command, CancellationToken token)
        {
            // var department = Department.Create(command.Name, command.Budget, command.StartDate, command.Administrator);
            // await _departmentDbContext.Departments.AddAsync(department, token);
            //
            // await _eventProcessor.ProcessAsync(department.Events);
            //
            // await _departmentDbContext.CommitTransactionAsync(token);
        }
    }
}