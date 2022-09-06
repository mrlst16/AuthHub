using AuthHub.BLL.Common.Extensions;
using AuthHub.Models.Enums;
using AuthHub.Models.Requests;
using AuthHub.Models.Tokens;
using AuthHub.ServiceRegistrations;
using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthHub.Controllers
{
    [Route("api/token")]
    public class TokenController : Controller
    {
        private readonly IValidatorFactory _validatorFactory;
        private readonly TokenServiceFactory _tokenService;

        public TokenController(
            IValidatorFactory validatorFactory,
            TokenServiceFactory tokenServiceFactory
            )
        {
            _validatorFactory = validatorFactory;
            _tokenService = tokenServiceFactory;
        }

        [HttpGet("get_jwt_token")]
        public async Task<IActionResult> GetJWTToken(
            [FromQuery] Guid authSettingsId
            )
        {
            var (username, password) = Request.GetUsernameAndPassword();

            var request = new PasswordRequest()
            {
                AuthSettingsId = authSettingsId,
                UserName = username,
                Password = password
            };

            var service = _tokenService(AuthSchemeEnum.JWT);

            _validatorFactory.ValidateAndThrow<PasswordRequest>(request);
            var response = new ApiResponse<Token>()
            {
                Data = await service.GetToken(authSettingsId, username, password),
                SuccessMessage = "Successfully got token",
                Sucess = true
            };
            return new OkObjectResult(response);
        }

        [HttpGet("get_org_jwt_token")]
        public async Task<IActionResult> GetOrgJWTToken(
            )
        {
            var (username, password) = Request.GetUsernameAndPassword();

            var service = _tokenService(AuthSchemeEnum.JWT);

            var response = new ApiResponse<Token>()
            {
                Data = await service.GetTokenForAudderClients(username, password),
                SuccessMessage = "Successfully got token",
                Sucess = true
            };
            return new OkObjectResult(response);
        }
    }
}