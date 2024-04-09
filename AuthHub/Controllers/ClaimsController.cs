using AuthHub.Api.Attributes;
using AuthHub.Interfaces.Claims;
using AuthHub.Models.Requests;
using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AuthHub.Api.Controllers
{
    [APICredentials]
    [Route("api/claims")]
    [ApiController]
    public class ClaimsController : Controller
    {
        private readonly IClaimsService _claimsService;

        public ClaimsController(
            IClaimsService claimsService
            )
        {
            _claimsService = claimsService;
        }

        [HttpPost("set")]
        public async Task<IActionResult> AddClaims(
            [FromBody] SetClaimsRequest request
            )
        {
            await _claimsService.SetClaims(
                request.UserId,
                request.Claims.ToDictionary(x => x.Key, y => y.Value)
            );

            var response = new ApiResponse<bool>()
            {
                Data = true,
                Success = true,
                SuccessMessage = "Successfully added claim to user"
            };
            return new OkObjectResult(response);
        }
    }
}
