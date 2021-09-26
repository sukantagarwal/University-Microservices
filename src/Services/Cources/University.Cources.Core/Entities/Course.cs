using System;
using BuildingBlocks.Types;
using University.Cources.Core.Events;

namespace University.Cources.Core.Entities
{
    public class Course : BaseAggregateRoot<Course, Guid>
    {
        private Course(Guid id, Guid? departmentId, string title, int credits)
        {
            Id = id;
            Credits = credits;
            Title = title;
            DepartmentId = departmentId;

            AddEvent(new CourseCreatedDomainEvent(id, credits, title, departmentId));
        }

        public string Title { get; set; }
        public int Credits { get; set; }
        public Guid? DepartmentId { get; set; }

        public static Course Create(Guid id, Guid? departmentId, string title, int credits)
        {
            return new(id, departmentId, title, credits);
        }
    }
}