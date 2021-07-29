using System;
using System.Collections.Generic;
using MicroPack.Types;
using University.Instructors.Core.Events;
using University.Instructors.Core.ValueObjects;

namespace University.Instructors.Core.Entities
{
    public class Instructor: BaseAggregateRoot<Instructor, Guid>
    {
        
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public DateTime HireDate { get; private set; }
        public string FullName => LastName + " " + FirstName;
        public OfficeLocation OfficeLocation { get; private set; }

        public Instructor()
        {
            
        }
        
        private Instructor(Guid id, string firstName, string lastName, DateTime hireDate, OfficeLocation officeLocation)
        {
            //CheckRule(new DepartmentMustHavePositiveBudgetRule(budget));
            
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            HireDate = hireDate;
            OfficeLocation = OfficeLocation.CreateNew(officeLocation.Address, officeLocation.PostalCode, officeLocation.City);

            AddEvent(new InstructorCreatedDomainEvent(id, lastName, firstName, hireDate, OfficeLocation));
        }

        public static Instructor Create(string firstName, string lastName, DateTime hireDate, OfficeLocation officeLocation)
        {
            return new Instructor(Guid.NewGuid(), firstName, lastName, hireDate, officeLocation);
        }

    }
}