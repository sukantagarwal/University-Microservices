using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.One.Controllers
{
    public class SecretController: Controller
    {
        [Route("/secret")]
        [Authorize]
        public string Index()
        {
            return "secret message from scope 1";
        }
    }
}