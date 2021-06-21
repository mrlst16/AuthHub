using AuthHub.BLL.Extensions;
using AuthHub.BLL.Tokens;
using AuthHub.Extensions;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using AuthHub.ServiceRegistrations;
using CommonCore.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
namespace AuthHub.Controllers
{
    [Route("api")]
    public class TokenController : Controller
    {
        private readonly IValidatorFactory _validatorFactory;
        private readonly ITokenGeneratoryFactory _tokenServiceFactory;
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IConfiguration _configuration;

        public TokenController(
            IValidatorFactory validatorFactory,
            ITokenGeneratoryFactory tokenServiceFactory,
            IOrganizationLoader organizationLoader,
            IConfiguration configuration
            )
        {
            _validatorFactory = validatorFactory;
            _tokenServiceFactory = tokenServiceFactory;
            _organizationLoader = organizationLoader;
            _configuration = configuration;
        }

        [HttpGet("get_jwt_token")]
        public async Task<IActionResult> GetJWTToken(
            [FromQuery] Guid organizationId
            )
        {
            var (username, password) = Request.GetUsernameAndPassword();

            var request = new PasswordRequest()
            {
                OrganizationID = organizationId,
                UserName = username,
                Password = password
            };
            var org = await _organizationLoader.Get(organizationId);
            var service = _tokenServiceFactory.Get<JWTTokenGenerator>();

            _validatorFactory.ValidateAndThrow<PasswordRequest>(request);
            var response = new ApiResponse<Token>()
            {
                Data = await service.GetToken(request, org),
                SuccessMessage = "Successfully get token",
                Sucess = true
            };
            return new OkObjectResult(response);
        }

        [HttpGet("get_org_jwt_token")]
        public async Task<IActionResult> GetOrgJWTToken(
            )
        {
            var (username, password) = Request.GetUsernameAndPassword();
            var organizationId = _configuration.AuthHubOrganizationId();
            var request = new PasswordRequest()
            {
                OrganizationID = organizationId,
                UserName = username,
                Password = password,
                SettingsName = "audder_clients"
            };
            var org = await _organizationLoader.Get(organizationId);
            var service = _tokenServiceFactory.Get<JWTTokenGenerator>();

            _validatorFactory.ValidateAndThrow<PasswordRequest>(request);

            var response = new ApiResponse<Token>()
            {
                Data = await service.GetToken(request, org),
                SuccessMessage = "Successfully get token",
                Sucess = true
            };
            return new OkObjectResult(response);
        }
    }
}