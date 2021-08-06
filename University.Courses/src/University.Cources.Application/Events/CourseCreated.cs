using System;
using BuildingBlocks.CQRS.Events;

namespace University.Cources.Application.Events
{
    public class CourseCreated: IEvent
    {
        public Guid Id { get; }

        public CourseCreated(Guid id)
        {
            Id = id;
        }
    }
}