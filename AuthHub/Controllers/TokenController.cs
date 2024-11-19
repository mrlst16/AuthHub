using AuthHub.Api.Attributes;
using AuthHub.Api.Helpers;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Enums;
using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthHub.Models.Responses.Tokens;

namespace AuthHub.Api.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly Func<AuthSchemeEnum, ITokenService> _tokenService;

        public TokenController(
            Func<AuthSchemeEnum, ITokenService> tokenService
            )
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        [APIAndUserCredentials]
        public async Task<IActionResult> GetJWTUserToken()
        {
            return new OkObjectResult(new ApiResponse<TokenResponse>()
            {
                Data = await _tokenService(AuthSchemeEnum.JWT).GetAsync(User.GetOrganizationId(), User.GetUserName()),
                Success = true,
                SuccessMessage = "Successfully verified user email"
            });
        }

        [HttpGet("refresh")]
        [ApiAndLoggedInUser]
        public async Task<IActionResult> RefreshJWTUserToken(
            [FromQuery] string refreshToken
        )
        {
            return new OkObjectResult(new ApiResponse<TokenResponse>()
            {
                Data = await _tokenService(AuthSchemeEnum.JWT).GetRefreshTokenAsync(User.GetUserId(), refreshToken),
                Success = true,
                SuccessMessage = "Successfully refreshed token"
            });
        }

        [HttpGet("JWTUserTokenPhoneLogin")]
        public async Task<IActionResult> GetJWTUserTokenPhoneLogin(
            [FromQuery] string phoneNumber,
            [FromQuery] string verificationCode
            )
        {
            return new OkObjectResult(new ApiResponse<TokenResponse>()
            {
                Data = await _tokenService(AuthSchemeEnum.JWT).GetByPhoneVerificationCodeAsync(phoneNumber, verificationCode),
                Success = true,
                SuccessMessage = "Successfully logged in via phone"
            });
        }
    }
}