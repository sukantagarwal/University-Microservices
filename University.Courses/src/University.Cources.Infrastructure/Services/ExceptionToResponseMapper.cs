using System;
using System.Net;
using BuildingBlocks.Exception;
using University.Cources.Application.Exceptions;
using University.Cources.Core.Exceptions;

namespace University.Cources.Infrastructure.Services
{
    public class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
        {
            return exception switch
            {
                DomainException ex => new ExceptionResponse(new {reason = ex.Message},
                    HttpStatusCode.BadRequest),
                AppException ex => new ExceptionResponse(new {reason = ex.Message},
                    HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new {code = "error", reason = "There was an error."},
                    HttpStatusCode.BadRequest)
            };
        }
    }
}