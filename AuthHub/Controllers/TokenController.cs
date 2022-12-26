using AuthHub.Api.Attributes;
using AuthHub.Api.Helpers;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Entities.Tokens;
using Common.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthHub.Models.Enums;

namespace AuthHub.Api.Controllers
{
    [Route("api/token")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class TokenController : Controller
    {
        private readonly Func<AuthSchemeEnum, ITokenService> _tokenService;

        public TokenController(
            Func<AuthSchemeEnum, ITokenService> tokenService
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
                Data = await _tokenService(AuthSchemeEnum.JWT).GetAsync(userId),
                Success = true,
                SuccessMessage = "Successfully verified user email"
            });
        }

        [HttpGet("RefreshJWTUserToken")]
        [APICredentials]
        public async Task<IActionResult> RefreshJWTUserToken(
            [FromQuery] Guid userId,
            [FromQuery] string refreshToken
        )
        {
            return new OkObjectResult(new ApiResponse<Token>()
            {
                Data = await _tokenService(AuthSchemeEnum.JWT).GetRefreshToken(userId, refreshToken),
                Success = true,
                SuccessMessage = "Successfully verified user email"
            });
        }

    }
}