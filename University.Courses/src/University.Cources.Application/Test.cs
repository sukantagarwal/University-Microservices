using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using University.Cources.Application.Events.External;

namespace University.Cources.Application
{
    public class Test : ICapSubscribe
    {
        private readonly ILogger<Test> _logger;

        public Test(ILogger<Test> logger)
        {
            _logger = logger;
        }

        [CapSubscribe("StudentCreated")]
        public void CheckReceivedMessage(StudentCreated student)
        {
            Task.Delay(5000).GetAwaiter().GetResult();
            _logger.LogInformation(JsonConvert.SerializeObject(student));
        }
    }
}