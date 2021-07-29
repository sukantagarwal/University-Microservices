using System.Threading;
using System.Threading.Tasks;
using MicroPack.CQRS.Commands;
using University.Cources.Application.Services;
using University.Cources.Core.Entities;

namespace University.Cources.Application.Commands.Handlers
{
    public class AddCourseHandler: ICommandHandler<AddCourse>
    {
        private readonly ICourseDbContext _courseDbContext;
        private readonly IEventProcessor _eventProcessor;

        public AddCourseHandler(ICourseDbContext courseDbContext, IEventProcessor eventProcessor)
        {
            _courseDbContext = courseDbContext;
            _eventProcessor = eventProcessor;
        }
        public async Task HandleAsync(AddCourse command, CancellationToken token)
        {
            var department = Course.Create(command.DepartmentId, command.Title, command.Credits);
            await _courseDbContext.Courses.AddAsync(department, token);
            
            await _eventProcessor.ProcessAsync(department.Events);
            
            await _courseDbContext.CommitTransactionAsync(token);
        }
    }
}