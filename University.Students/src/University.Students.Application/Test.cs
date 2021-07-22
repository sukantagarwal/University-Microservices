using System;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Humanizer;
using MicroPack.CQRS.Events;
using University.Students.Application.Commands;
using University.Students.Application.Events;
using Headers = DotNetCore.CAP.Messages.Headers;

namespace University.Students.Application
{
    public class StudentCreatedConsumer: ICapSubscribe
    {
        [CapSubscribe(nameof(StudentCreated))]
        public Task Handel(StudentCreated studentCreated)
        {
            Console.WriteLine($@"{studentCreated}");
            return Task.CompletedTask;
        }
    }
}