using AuthHub.BLL.Common.Tokens;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Requests;
using AuthHub.ServiceRegistrations;
using Common.Models.Responses;
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

    }
}
