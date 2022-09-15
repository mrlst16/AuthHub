using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Requests;
using Common.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("for_organization")]
        public async Task<IActionResult> ForOrganizationAsync(
            [FromBody] ResetOrganizationPasswordRequest request
        )
        {
            await _service.RequestOrganizationPasswordReset((request.OrganizationId, request.AuthSettingsName, request.UserName));
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
