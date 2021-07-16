using System.Threading.Tasks;
using MicroPack.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using University.Students.Application.Commands;

namespace University.Students.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public StudentController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(AddStudent command)
        {
            await _commandDispatcher.SendAsync(command);
            return Ok();
        }
    }
}