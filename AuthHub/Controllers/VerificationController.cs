using AuthHub.Interfaces.Verification;
using AuthHub.Models.Enums;
using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthHub.Api.Controllers
{
    [Route("api/verification")]
    [ApiController]
    public class VerificationController : Controller
    {
        public IVerificationCodeService _service { get; set; }

        public VerificationController(
            IVerificationCodeService service
            )
        {
            _service = service;
        }

        [HttpGet("user_email")]
        public async Task<IActionResult> Index(
            [FromQuery] Guid userId,
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

        [HttpGet("request_phone_code")]
        public async Task<IActionResult> RequestPhoneCodeAsync()
        {

            return new OkObjectResult(new ApiResponse<string>());
        }
    }
}
