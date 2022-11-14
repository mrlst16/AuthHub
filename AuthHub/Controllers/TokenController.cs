using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Requests;
using AuthHub.Models.Tokens;
using Common.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthHub.Api.Controllers
{
    [Route("api/token")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;

        public TokenController(
            ITokenService tokenService
            )
        {
            _tokenService = tokenService;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserAuthToken(
            [FromBody] SignInRequest request
        )
        {
            var response = new ApiResponse<Token>()
            {
                Data = await _tokenService.GetToken(request.AuthSettingsId, request.UserName, request.Password),
                Success = true,
                SuccessMessage = "Successfully retrieved token for user"
            };
            return new OkObjectResult(response);
        }
    }
}