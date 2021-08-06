using System;
using BuildingBlocks.CQRS.Events;

namespace University.Students.Application.Events.Rejected
{
    public class AddStudentRejected: IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }

        public AddStudentRejected(Guid id, string reason)
        {
            Id = id;
            Reason = reason;
        }
    }
}