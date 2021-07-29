using System;
using System.Collections.Generic;
using MicroPack.Types;

namespace University.Cources.Core.Entities
{
    public class Department: BaseAggregateRoot<Department, Guid>
    {

        public string Name { get; set; }
        
        public decimal Budget { get; set; }
        
        public DateTime StartDate { get; set; }

        public int? AdministratorId { get; set; }
        
        public ICollection<Course> Courses { get; set; }
    }
}