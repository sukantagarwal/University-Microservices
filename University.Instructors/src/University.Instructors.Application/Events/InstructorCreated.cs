using System;
using MicroPack.CQRS.Events;

namespace University.Instructors.Application.Events
{
    public class InstructorCreated: IEvent
    {
        public Guid Id { get;}

        public InstructorCreated(Guid id)
        {
            Id = id;
        }
    }
}