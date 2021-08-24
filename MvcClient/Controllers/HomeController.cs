using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController: Controller
    {
        [HttpGet(nameof(Index))]
        public IActionResult Index()
        {
            return View();
        }
        
        [Authorize]
        [HttpGet(nameof(Secret))]
        public IActionResult Secret()
        {
            return View();
        }
    }
}