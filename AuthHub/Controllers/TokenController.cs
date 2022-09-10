using AuthHub.BLL.Common.Extensions;
using AuthHub.Models.Enums;
using AuthHub.Models.Requests;
using AuthHub.Models.Tokens;
using AuthHub.ServiceRegistrations;
using Common.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthHub.Interfaces.Tokens;

namespace AuthHub.Controllers
{
    [Route("api/token")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class TokenController : Controller
    {
        private readonly IValidatorFactory _validatorFactory;
        private readonly ITokenService _tokenService;

        public TokenController(
            IValidatorFactory validatorFactory,
            ITokenService tokenService
            )
        {
            _validatorFactory = validatorFactory;
            _tokenService = tokenService;
        }

        [HttpGet("user_auth_token")]
        public async Task<IActionResult> GetUserAuthToken(
            [FromBody] Guid userId,
            [FromBody] string password
        )
        {
            var response = new ApiResponse<Token>()
            {
                Data = await _tokenService.GetToken(userId, password),
                Sucess = true,
                SuccessMessage = "Successfully retrieved token for user"
            };
            return new OkObjectResult(response);
        }
    }
}