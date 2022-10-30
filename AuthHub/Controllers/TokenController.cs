﻿using System.Threading.Tasks;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Tokens;
using Common.Models.Responses;
using FluentValidation;
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

        [HttpGet("user")]
        public async Task<IActionResult> GetUserAuthToken(
            [FromBody] Guid userId,
            [FromBody] string password
        )
        {
            var response = new ApiResponse<Token>()
            {
                Data = await _tokenService.GetToken(userId, password),
                Success = true,
                SuccessMessage = "Successfully retrieved token for user"
            };
            return new OkObjectResult(response);
        }
    }
}