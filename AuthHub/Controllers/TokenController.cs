﻿using AuthHub.Api.Attributes;
using AuthHub.Api.Helpers;
using AuthHub.Interfaces.Tokens;
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

        [HttpGet("JWTUserToken")]
        [APICredentials]
        [UserCredentials]
        public async Task<IActionResult> GetJWTUserToken()
        {
            var userId = User.GetUserId();

            return new OkObjectResult(new ApiResponse<Token>()
            {
                Data = await _tokenService.GetAsync(userId),
                Success = true,
                SuccessMessage = "Successfully verified user email"
            });
        }

    }
}