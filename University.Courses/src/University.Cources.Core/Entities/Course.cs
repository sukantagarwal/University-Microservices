using System;
using System.Collections.Generic;
using MicroPack.Types;
using University.Cources.Core.Events;
using University.Cources.Core.Exceptions;

namespace University.Cources.Core.Entities
{
    public class Course: BaseAggregateRoot<Course, Guid>
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public Guid DepartmentId { get; set; }


        private Course(Guid id, Guid departmentId, string title, int credits)
        {
            ValidateCredits(credits);
            ValidateTitle(title);
            ValidateDepartmentId(departmentId);
            
            Id = id;
            Credits = credits;
            Title = title;
            DepartmentId = departmentId;

            AddEvent(new CourseCreatedDomainEvent(id, credits, title, departmentId));
        }
        
        private static void ValidateCredits(int credits)
        {
            if (credits <= 0)
            {
                throw new InvalidCreditsException();
            }
        }
        
        private static void ValidateTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new InvalidTitleException();
            }
        }

        private static void ValidateDepartmentId(Guid departmentId)
        {
            if (departmentId == null)
            {
                throw new InvalidDepartmentIdException();
            }
        }


        public static Course Create(Guid departmentId, string title, int credits)
        {
            return new Course(Guid.NewGuid(), departmentId, title, credits);
        }
    }
}