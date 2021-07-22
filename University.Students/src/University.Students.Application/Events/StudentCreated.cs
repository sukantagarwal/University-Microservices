using System;
using MicroPack.CQRS.Events;

namespace University.Students.Application.Events
{
    public class StudentCreated: IEvent
    {
        public Guid Id { get; }

        public StudentCreated(Guid id)
        {
            Id = id;
        }
    }
}