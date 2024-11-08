﻿using AuthHub.Api.Attributes;
using AuthHub.Api.Helpers;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Enums;
using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            [FromQuery] int userId,
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

        [HttpGet("JWTUserTokenPhoneLogin")]
        public async Task<IActionResult> GetJWTUserTokenPhoneLogin(
            [FromQuery] string phoneNumber,
            [FromQuery] string verificationCode
            )
        {
            return new OkObjectResult(new ApiResponse<Token>()
            {
                Data = await _tokenService(AuthSchemeEnum.JWT).GetByPhoneVerificationCode(phoneNumber, verificationCode),
                Success = true,
                SuccessMessage = "Successfully verified user email"
            });
        }
    }
}