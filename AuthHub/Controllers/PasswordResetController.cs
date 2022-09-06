using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Requests;
using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthHub.Controllers
{
    public class PasswordResetController : Controller
    {
        private readonly IPasswordResetService _service;

        public PasswordResetController(
            IPasswordResetService service
            )
        {
            _service = service;
        }

        [HttpPost("request_organization_password_reset")]
        public async Task<IActionResult> RequestPasswordResetForOrganization(
            [FromBody] ResetOrganizationPasswordRequest request
        )
        {
            await _service.RequestOrganizationPasswordReset((request.OrganizationId, request.AuthSettingsName, request.UserName));
            var response = new ApiResponse<bool>()
            {
                Data = true,
                Sucess = true,
                SuccessMessage = "Successfully requested a password reset token to be sent to your email"
            };
            return new OkObjectResult(response);
        }



        [HttpPut("set")]
        public async Task<IActionResult> ResetPassword(
            [FromBody] SetPasswordRequest request
        )
        {
            await _service.ResetOrganizationPassword(request);
            var response = new ApiResponse<bool>()
            {
                Data = true,
                Sucess = true,
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
                Sucess = true,
                SuccessMessage = "Successfully requested a password reset token to be sent to your email"
            };
            return new OkObjectResult(response);
        }
    }
}
