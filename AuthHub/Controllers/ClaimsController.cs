﻿using System.Linq;
using System.Threading.Tasks;
using AuthHub.Api.Attributes;
using AuthHub.Api.Helpers;
using AuthHub.Interfaces.Claims;
using AuthHub.Models.Requests;
using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    [APICredentials]
    [UserCredentials]
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
            var userid = User.GetUserId();
            await _claimsService.SetClaims(
                userid, 
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
