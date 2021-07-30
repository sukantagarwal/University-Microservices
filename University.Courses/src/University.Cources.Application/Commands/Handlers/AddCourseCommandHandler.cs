using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MicroPack.CQRS.Commands;
using University.Cources.Application.Exceptions;
using University.Cources.Application.Services;
using University.Cources.Core.Entities;

namespace University.Cources.Application.Commands.Handlers
{
    public class AddCourseCommandHandler: ICommandHandler<AddCourseCommand>
    {
        private readonly ICourseDbContext _courseDbContext;
        private readonly IEventProcessor _eventProcessor;

        public AddCourseCommandHandler(ICourseDbContext courseDbContext, IEventProcessor eventProcessor)
        {
            _courseDbContext = courseDbContext;
            _eventProcessor = eventProcessor;
        }
        public async Task HandleAsync(AddCourseCommand command, CancellationToken token)
        {
            var duplicateTitle = _courseDbContext.Courses.Any(x=>x.Title == command.Title);
            if (duplicateTitle)
            {
                throw new DuplicateTitleException();
            }
            
            var course = Course.Create(command.DepartmentId, command.Title, command.Credits);
            await _courseDbContext.Courses.AddAsync(course, token);
            
            await _eventProcessor.ProcessAsync(course.Events);
            
            await _courseDbContext.CommitTransactionAsync(token);
        }
    }
}