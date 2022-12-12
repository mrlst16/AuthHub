using AuthHub.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    [APICredentials]
    [UserCredentials]
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        [HttpGet("balls")]
        public IActionResult Index()
        {
            var user = User;
            return Ok("Balls!");
        }
    }
}
