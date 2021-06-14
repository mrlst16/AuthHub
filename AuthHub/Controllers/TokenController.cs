using AuthHub.BLL.Tokens;
using AuthHub.Extensions;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Passwords;
using AuthHub.ServiceRegistrations;
using CommonCore.Models.Responses;
using Microsoft.AspNetCore.Mvc;
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

        public TokenController(
            IValidatorFactory validatorFactory,
            ITokenGeneratoryFactory tokenServiceFactory,
            IOrganizationLoader organizationLoader
            )
        {
            _validatorFactory = validatorFactory;
            _tokenServiceFactory = tokenServiceFactory;
            _organizationLoader = organizationLoader;
        }

        [HttpGet("get_jwt_token")]
        public async Task<IActionResult> GetJWTToken(
            [FromQuery] Guid organizationId
            )
        {
            var (username, password) = Request.Headers["Authorization"].ToString().DecodeBasicAuth();

            var request = new PasswordRequest()
            {
                OrganizationID = organizationId,
                UserName = username,
                Password = password
            };
            var org = await _organizationLoader.Get(organizationId);
            var service = _tokenServiceFactory.Get<JWTTokenGenerator>();

            _validatorFactory.ValidateAndThrow<PasswordRequest>(request);
            var response = new ApiResponse<string>()
            {
                Data = await service.GetToken(request, org),
                SuccessMessage = "Successfully get token",
                Sucess = true
            };
            return new OkObjectResult(response);
        }
    }
}
