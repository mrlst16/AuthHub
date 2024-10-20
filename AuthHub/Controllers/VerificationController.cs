using AuthHub.Interfaces.Verification;
using AuthHub.Models.Enums;
using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthHub.Models.Entities.Verification;
using AuthHub.Models.Requests;
using AuthHub.Models.Responses.Verification;
using FluentValidation;

namespace AuthHub.Api.Controllers
{
    [Route("api/verification")]
    [ApiController]
    public class VerificationController : Controller
    {
        private readonly IVerificationCodeService _service;
        private readonly IValidator<PhoneLoginCodeRequest> _phoneLoginCodeRequestValidator;

        public VerificationController(
            IVerificationCodeService service,
            IValidator<PhoneLoginCodeRequest> phoneLoginCodeRequestValidator
            )
        {
            _service = service;
            _phoneLoginCodeRequestValidator = phoneLoginCodeRequestValidator;
        }

        [HttpGet("user_email")]
        public async Task<IActionResult> Index(
            [FromQuery] int userId,
            [FromQuery] string code
            )
        {
            return new OkObjectResult(new ApiResponse<bool>()
            {
                Data = await _service.VerifyAndRecordCode(userId, VerificationTypeEnum.UserEmail, code),
                Success = true,
                SuccessMessage = "Successfully verified user email"
            });
        }

        [HttpGet("request_phone_login_code")]
        public async Task<IActionResult> RequestPhoneCodeAsync(
            [FromQuery] PhoneLoginCodeRequest request
        )
        {
            await _phoneLoginCodeRequestValidator.ValidateAndThrowAsync(request);

            return new OkObjectResult(new ApiResponse<VerificationCodeResponse>()
            {
                Data = await _service.GenerateSendAndSavePhoneLoginCode(request.PhoneNumber),
                Success = true,
            });
        }
    }
}
