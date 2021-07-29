using System;
using System.Collections.Generic;
using MicroPack.Types;
using University.Cources.Core.Events;

namespace University.Cources.Core.Entities
{
    public class Course: BaseAggregateRoot<Course, Guid>
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public Guid DepartmentId { get; set; }


        private Course(Guid id, Guid departmentId, string title,int credits)
        {
            //CheckRule(new DepartmentMustHavePositiveBudgetRule(budget));
            Id = id;
            Credits = credits;
            Title = title;
            DepartmentId = departmentId;

            AddEvent(new CourseCreatedDomainEvent(id, credits, title, departmentId));
        }

        public static Course Create(Guid departmentId, string title, int credits)
        {
            return new Course(Guid.NewGuid(), departmentId, title, credits);
        }
    }
}