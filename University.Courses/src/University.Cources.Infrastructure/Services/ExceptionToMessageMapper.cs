using System;
using BuildingBlocks.CQRS.Events;
using BuildingBlocks.Exception;
using University.Cources.Application.Events.Rejected;
using University.Cources.Application.Exceptions;

namespace University.Cources.Infrastructure.Services
{
    public class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public IRejectedEvent Map(Exception exception, object message)
        {
            return exception switch
            {
                DuplicateTitleException ex => new AddCourseRejected(ex.Id, ex.Message),
                _ => null
            };
        }
    }
}