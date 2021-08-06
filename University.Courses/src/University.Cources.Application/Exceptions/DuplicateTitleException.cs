using System;

namespace University.Cources.Application.Exceptions
{
    public class DuplicateTitleException: AppException
    {
        public Guid Id { get; }

        public DuplicateTitleException(Guid id) : base("title already exist!")
        {
            Id = id;
        }
    }
}