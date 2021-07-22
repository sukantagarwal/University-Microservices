using System;
using System.Threading.Tasks;
using DotNetCore.CAP;
using DotNetCore.CAP.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using University.Students.Application;

namespace University.Students.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly ICapPublisher _capBus;

        public ValuesController(ICapPublisher capPublisher)
        {
            _capBus = capPublisher;
        }

        [HttpGet(nameof(WithoutTransaction))]
        public async Task<IActionResult> WithoutTransaction()
        {
            await _capBus.PublishAsync("sample.rabbitmq.sqlserver", new Person()
            {
                Id = 123,
                Name = "Bar"
            });

            return Ok();
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}