using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Requests;
using Common.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthHub.Api.Controllers
{
    [Route("api/password_reset")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class PasswordResetController : Controller
    {
        private readonly IPasswordResetService _service;
        private readonly IValidator<ResetPasswordRequest> _resetPasswordRequestValidator;

        public PasswordResetController(
            IPasswordResetService service,
            IValidator<ResetPasswordRequest> resetPasswordRequestValidator
            )
        {
            _service = service;
            _resetPasswordRequestValidator = resetPasswordRequestValidator;
        }

        [HttpPost()]
        public async Task<IActionResult> ResetPassword(
            [FromQuery] ResetPasswordRequest request
        )
        {
            await _service.ResetUserPassword(request);
            var response = new ApiResponse<bool>()
            {
                Data = true,
                Success = true,
                SuccessMessage = "Successfully reset password"
            };
            return new OkObjectResult(response);
        }

        [HttpPost("request_user_password_reset")]
        public async Task<IActionResult> RequestPasswordResetForUser(
            [FromBody] ResetUserPasswordRequest request
        )
        {
            await _service.RequestPasswordResetForUser(request.UserId);
            var response = new ApiResponse<bool>()
            {
                Data = true,
                Success = true,
                SuccessMessage = "Successfully requested a password reset token to be sent to your email"
            };
            return new OkObjectResult(response);
        }
    }
}
