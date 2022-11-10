using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Requests;
using Common.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthHub.Controllers
{
    [Route("api/password_reset")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class PasswordResetController : Controller
    {
        private readonly IPasswordResetService _service;

        public PasswordResetController(
            IPasswordResetService service
            )
        {
            _service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> ResetPassword(
            [FromBody] SetPasswordRequest request
        )
        {
            await _service.ResetOrganizationPassword(request);
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
