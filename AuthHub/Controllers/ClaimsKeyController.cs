﻿using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Passwords;
using Common.Models.Exceptions;
using Common.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.Controllers
{
    [Route("api/claimskey")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class ClaimsKeyController : Controller
    {
        private readonly IClaimsKeyService _service;

        public ClaimsKeyController(
            IClaimsKeyService service
            )
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(
            [FromQuery] Guid authSettingsId
            )
        {
            if (authSettingsId == Guid.Empty)
                throw new HttpException("authSettingsId does not contain a valid value", 400);

            var response = new ApiResponse<IEnumerable<ClaimsKey>>()
            {
                Data = await _service.GetAsync(authSettingsId),
                SuccessMessage = "Successfully get token",
                Success = true
            };
            return new OkObjectResult(response);
        }
    }
}
