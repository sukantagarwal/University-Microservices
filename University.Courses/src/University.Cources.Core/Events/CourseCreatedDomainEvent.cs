﻿using System;
using MicroPack.Types;

namespace University.Cources.Core.Events
{
    public class CourseCreatedDomainEvent: IDomainEvent
    {
        public Guid Id { get;}
        public string Title { get;}
        public int Credits { get;}
        public Guid DepartmentId { get;}

        public CourseCreatedDomainEvent(Guid id, int credits, string title, Guid departmentId)
        {
            Id = id;
            Title = title;
            Credits = credits;
            DepartmentId = departmentId;
        }
    }
}