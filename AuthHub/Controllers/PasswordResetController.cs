using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Requests;
using Common.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthHub.Api.Attributes;
using AuthHub.Models.Entities.Passwords;

namespace AuthHub.Api.Controllers
{
    [Route("api/password_reset")]
    [ApiController]
    public class PasswordResetController : Controller
    {
        private readonly IPasswordResetService _service;

        public PasswordResetController(
            IPasswordResetService service
            )
        {
            _service = service;
        }

        [HttpPost("reset_password")]
        public async Task<IActionResult> ResetPassword(
            [FromBody] ResetPasswordRequest request
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

        [APICredentials]
        [HttpPost("request_user_password_reset")]
        public async Task<IActionResult> RequestPasswordResetForUser(
            [FromBody] ResetUserPasswordRequest request
        )
        {
            var result = await _service.RequestPasswordResetForUser(request.UserId);
            var response = new ApiResponse<PasswordResetToken>()
            {
                Data = result,
                Success = true,
                SuccessMessage = "Successfully requested a password reset token to be sent to your email"
            };
            return new OkObjectResult(response);
        }
    }
}
