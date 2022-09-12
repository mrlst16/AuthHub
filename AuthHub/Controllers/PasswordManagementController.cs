﻿using AuthHub.BLL.Common.Tokens;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Requests;
using AuthHub.ServiceRegistrations;
using Common.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthHub.Controllers
{
    [Route("api/password_management")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class PasswordManagementController : Controller
    {
        private readonly IValidatorFactory _validatorFactory;
        private readonly IPasswordService _service;

        public PasswordManagementController(
            IValidatorFactory validatorFactory,
            IPasswordService service
            )
        {
            _validatorFactory = validatorFactory;
            _service = service;
        }

        [HttpPost("set")]
        public async Task<IActionResult> SetPassword(
            [FromBody] PasswordRequest request
            )
        {
            _validatorFactory.ValidateAndThrow<PasswordRequest>(request);
            var (success, passwordRecord) = await _service.Set<JWTTokenGenerator>(request);
            var response = new ApiResponse<bool>()
            {
                Data = success,
                Success = success,
                SuccessMessage = "Successfully set password"
            };
            return new OkObjectResult(response);
        }

    }
}
