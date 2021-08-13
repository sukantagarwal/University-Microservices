using BuildingBlocks.OpenTelemetry.Messaging;
using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using University.Students.Application.Events;

namespace University.Students.Application
{
    public class Test : ICapSubscribe
    {
        private readonly ILogger<Test> _logger;

        public Test(ILogger<Test> logger)
        {
            _logger = logger;
        }

        [CapSubscribe(nameof(StudentCreated))]
        public void CheckReceivedMessage(StudentCreated student)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(student));
        }
    }
}