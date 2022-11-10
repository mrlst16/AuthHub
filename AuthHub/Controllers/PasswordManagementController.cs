using System.Threading.Tasks;
using AuthHub.BLL.Common.Tokens;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Requests;
using Common.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    [Route("api/password_management")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class PasswordManagementController : Controller
    {
        private readonly IPasswordService _service;

        public PasswordManagementController(
            IPasswordService service
            )
        {
            _service = service;
        }

        [HttpPost("set")]
        public async Task<IActionResult> SetPassword(
            [FromBody] PasswordRequest request
            )
        {
            var (success, passwordRecord) = await _service.Set<JWTTokenGenerator>(request);
            var response = new ApiResponse<bool>()
            {
                Data = success,
                Success = success,
                SuccessMessage = "Successfully set password"
            };
            return new OkObjectResult(response);
        }

    }
}
