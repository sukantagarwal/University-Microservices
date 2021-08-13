using System;
using BuildingBlocks.CQRS.Events;

namespace University.Cources.Application.Events
{
    public class CourseCreated : IEvent
    {
        public CourseCreated(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}