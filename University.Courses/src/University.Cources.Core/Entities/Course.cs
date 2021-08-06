using System;
using System.Collections.Generic;
using BuildingBlocks.Types;
using University.Cources.Core.Events;
using University.Cources.Core.Exceptions;

namespace University.Cources.Core.Entities
{
    public class Course: BaseAggregateRoot<Course, Guid>
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public Guid? DepartmentId { get; set; }


        private Course(Guid id, Guid? departmentId, string title, int credits)
        {
            Id = id;
            Credits = credits;
            Title = title;
            DepartmentId = departmentId;

            AddEvent(new CourseCreatedDomainEvent(id, credits, title, departmentId));
        }
        
        public static Course Create(Guid id , Guid? departmentId, string title, int credits)
        {
            return new Course(id , departmentId, title, credits);
        }
    }
}