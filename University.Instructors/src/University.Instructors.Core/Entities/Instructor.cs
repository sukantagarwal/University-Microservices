using System;
using System.Collections.Generic;
using MicroPack.Types;
using University.Instructors.Core.Events;
using University.Instructors.Core.ValueObjects;

namespace University.Instructors.Core.Entities
{
    public class Instructor: BaseAggregateRoot<Instructor, Guid>
    {
        private OfficeLocation _officeLocation;
        
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public string FullName => LastName + " " + FirstName;
        public OfficeLocation OfficeLocation => _officeLocation;  

        public ICollection<CourseAssignment> CourseAssignments { get; private set; } = new List<CourseAssignment>();
        public ICollection<Department> Departments { get; private set; }
        
        
        private Instructor(Guid id, string firstName, string lastName, DateTime hireDate, string address,string postalCode,string city)
        {
            //CheckRule(new DepartmentMustHavePositiveBudgetRule(budget));
            
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            HireDate = hireDate;
            _officeLocation = OfficeLocation.CreateNew(address, postalCode, city);

            AddEvent(new InstructorCreatedDomainEvent(id, lastName, firstName, hireDate, _officeLocation));
        }

        public static Instructor Create(string firstName, string lastName, DateTime hireDate, string address, string postalCode, string city)
        {
            return new Instructor(Guid.NewGuid(), firstName, lastName, hireDate, address, postalCode, city);
        }

    }
}