using AuthHub.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    [APICredentials]
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        [HttpGet("balls")]
        public IActionResult Index()
        {
            return Ok("Balls!");
        }
    }
}
