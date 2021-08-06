using System;
using University.Students.Application.Exceptions;

public class DuplicateException: AppException
{
    public Guid Id { get; }

    public DuplicateException(Guid id) : base("title already exist!")
    {
        Id = id;
    }
}