using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MicroPack.Types;
using University.Departments.Core.Events;

namespace University.Departments.Core.Entities
{
    public class Department: BaseAggregateRoot<Department, Guid>
    {
        public string Name { get; set; }
        
        public decimal Budget { get; set; }
        
        public DateTime StartDate { get; set; }

        public Guid? InstructorId { get; set; }
        
        private readonly List<Course> _courses = new List<Course>();
        public IReadOnlyCollection<Course> Courses => _courses.ToImmutableArray();

        public Department()
        {
            
        }
        private Department(Guid id,string name, decimal budget, DateTime startDate, Guid? administratorId)
        {
            //CheckRule(new DepartmentMustHavePositiveBudgetRule(budget));
            Id = id;
            Name = name;
            Budget = budget;
            StartDate= startDate;
            InstructorId = administratorId;
            
            AddEvent(new DepartmentCreatedDomainEvent(id, name, budget, startDate, administratorId));
        }
        public static Department Create(string name, decimal budget, DateTime startDate, Guid? administratorId)
        {
            return new Department(Guid.NewGuid(), name, budget ,startDate, administratorId);
        }
    }
}