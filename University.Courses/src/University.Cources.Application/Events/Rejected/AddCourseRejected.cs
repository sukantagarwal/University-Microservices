using System;
using BuildingBlocks.CQRS.Events;

namespace University.Cources.Application.Events.Rejected
{
    public class AddCourseRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }

        public AddCourseRejected(Guid id, string reason)
        {
            Id = id;
            Reason = reason;
        }
    }
}