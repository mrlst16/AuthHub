using AuthHub.Models.Requests.Claims;
using AuthHub.SDK.Extensions;
using AuthHub.SDK.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTestClient.Controllers
{
    [ApiController]
    [Route("api/claimsdemo")]
    public class ClaimsDemoController : Controller
    {
        private readonly IClaimsConnector _connector;

        public ClaimsDemoController(
            IClaimsConnector connector
            )
        {
            _connector = connector;
        }

        [HttpPost]
        public async Task<IActionResult> AddClaimsAsync(
            [FromBody] IEnumerable<ClaimRequest> claims
        )
        {
            await _connector.AddClaimsAsync(new AddClaimsRequest()
            {
                UserId = User.UserId(),
                Claims = claims
            });

            return new OkObjectResult(true);
        }

        [HttpPatch]
        public async Task<IActionResult> RemoveClaimsAsync(
            [FromBody] IEnumerable<string> keyNames
        )
        {
            await _connector.RemoveClaimsAsync(new RemoveClaimsRequest()
            {
                UserId = User.UserId(),
                ClaimsKeys = keyNames
            });

            return new OkObjectResult(true);
        }

        [HttpPut]
        public async Task<IActionResult> SetClaimsAsync(
            [FromBody] IEnumerable<ClaimRequest> claims
        )
        {
            await _connector.SetClaimsAsync(new SetClaimsRequest()
            {
                UserId = User.UserId(),
                Claims = claims
            });

            return new OkObjectResult(true);
        }

        [HttpGet]
        public async Task<IActionResult> GetClaimsAsync()
        {

            return new OkObjectResult(User.Claims.Select(x=> new
            {
                Name = x.Type,
                Value = x.Value,
            }));
        }
    }
}