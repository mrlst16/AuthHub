using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    [Route("balls")]
    [ApiController]
    public class BallsController : Controller
    {
        [HttpGet("get")]
        public IActionResult Get()
        {

            return Ok("Balls");
        }
    }
}
