using AuthHub.SDK.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTestClient.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController : Controller
    {
        [AuthHubAuthentication]
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return new OkObjectResult("Here is some data");
        }

        [HttpGet("unauthenticated")]
        public async Task<IActionResult> GetUnauthenticated()
        {
            return new OkObjectResult("Unauthenticated data");
        }
    }
}
