using AuthHub.Api.Attributes;
using AuthHub.Api.Responses;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Requests;
using Common.Interfaces.Utilities;
using Common.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthHub.Api.Controllers
{
    [Route("api/password_reset")]
    [ApiController]
    public class PasswordResetController : Controller
    {
        private readonly IPasswordResetService _service;
        private readonly IValidator<ResetPasswordRequest> _resetPasswordRequestValidator;
        private readonly IMapper<PasswordResetToken, RequestPasswordResetTokenResponse> _requestPasswordResetTokenResponseMapper;

        public PasswordResetController(
            IPasswordResetService service,
            IValidator<ResetPasswordRequest> resetPasswordRequestValidator,
            IMapper<PasswordResetToken, RequestPasswordResetTokenResponse> requestPasswordResetTokenResponseMapper
            )
        {
            _service = service;
            _resetPasswordRequestValidator = resetPasswordRequestValidator;
            _requestPasswordResetTokenResponseMapper = requestPasswordResetTokenResponseMapper;
        }

        [HttpPost()]
        public async Task<IActionResult> ResetPassword(
            [FromBody] ResetPasswordRequest request
        )
        {
            await _resetPasswordRequestValidator.ValidateAndThrowAsync(request);
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
            [FromBody] RequestPasswordResetRequest request
        )
        {
            var result = await _service.RequestPasswordResetForUser(request.Username);
            var response = new ApiResponse<RequestPasswordResetTokenResponse>()
            {
                Data = _requestPasswordResetTokenResponseMapper.Map(result),
                Success = true,
                SuccessMessage = "Successfully requested a password reset token to be sent to your email"
            };
            return new OkObjectResult(response);
        }
    }
}
