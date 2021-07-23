using System;
using MicroPack.CQRS.Events;

namespace University.Departments.Application.Events
{
    public class DepartmentCreated: IEvent
    {
        public Guid Id { get; }

        public DepartmentCreated(Guid id)
        {
            Id = id;
        }
    }
}