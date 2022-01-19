using AuthHub.BLL.Common.Tokens;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Passwords;
using AuthHub.ServiceRegistrations;
using CommonCore.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthHub.Controllers
{
    [Route("api/password")]
    public class PasswordController : Controller
    {
        private readonly IValidatorFactory _validatorFactory;
        private readonly IPasswordService _service;

        public PasswordController(
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
                Sucess = success,
                SuccessMessage = "Successfully set password"
            };
            return new OkObjectResult(response);
        }

        [AllowAnonymous]
        [HttpPost("request_reset")]
        public async Task<IActionResult> RequestPasswordReset(
          [FromBody] RequestPasswordResetRequest request
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


        [HttpPatch("reset")]
        public async Task<IActionResult> ResetPassword(
            [FromBody] ResetPasswordRequest request
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
    }
}
