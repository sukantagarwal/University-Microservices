using System.Threading.Tasks;
using MicroPack.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using University.Departments.Application.Commands;

namespace University.Departments.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController: ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public DepartmentController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
        
        [HttpPost(nameof(Create))]
        public async Task<ActionResult> Create(AddDepartment command)
        {
            await _commandDispatcher.SendAsync(command);
            return Ok();
        }
    }
}