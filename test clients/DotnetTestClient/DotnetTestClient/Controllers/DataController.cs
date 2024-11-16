using AuthHub.SDK.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTestClient.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController : Controller
    {
        [AuthHubAuthentication, RequireClaim(name: "Key 1", value: "DfV1"), RequireClaim(name: "Key 2", value: "DfV")]
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
