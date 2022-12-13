using System.Linq;
using System.Threading.Tasks;
using AuthHub.Api.Attributes;
using AuthHub.Api.Helpers;
using AuthHub.Api.Middleware;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Enums;
using AuthHub.Models.Tokens;
using AuthHub.Models.Users;
using Common.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("JWTUserToken")]
        [APICredentials]
        [UserCredentials]
        public async Task<IActionResult> GetJWTUserToken()
        {
            var userId = User.GetUserId();

            return new OkObjectResult(new ApiResponse<Token>()
            {
                Data = await _tokenService.GetJWTUserToken(userId),
                Success = true,
                SuccessMessage = "Successfully verified user email"
            });
        }

    }
}