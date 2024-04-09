using System.Threading.Tasks;
using AuthHub.Api.Attributes;
using AuthHub.SDK.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    [APICredentials]
    [UserCredentials]
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly IVerificationConnector _verificationConnector;

        public TestController(
            IVerificationConnector verificationConnector
            )
        {
            _verificationConnector = verificationConnector;
        }

        [HttpGet("balls")]
        public IActionResult Index()
        {
            var user = User;
            return Ok("Balls!");
        }

        [HttpGet("request_phone_login_code")]
        public async Task<IActionResult> RequestPhoneLoginCodeAsync(
            [FromQuery] string phoneNumber
            )
        {
            return new OkObjectResult(await _verificationConnector.RequestPhoneLoginCode(phoneNumber));
        }
    }
}
