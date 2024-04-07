using AuthHub.Api.Attributes;
using AuthHub.Api.Helpers;
using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Responses.AuthSettings;
using Common.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AuthHub.Api.Controllers
{
    [APICredentials]
    [ApiController]
    [Route("[controller]")]
    public class AuthSettingsController : Controller
    {
        private readonly IOrganizationService _organizationService;

        public AuthSettingsController(
            IOrganizationService organizationService
            )
        {
            _organizationService = organizationService;
        }

        [APICredentials]
        [HttpGet("auth_settings")]
        public async Task<IActionResult> GetAuthSettings(
            [FromQuery] Guid authSettingsId
            )
        {
            if (authSettingsId == null || authSettingsId == Guid.Empty)
                throw new BadHttpRequestException("AuthSettingsId must be provided");

            var organizationId = User.GetOrganizationId();

            var organization = await _organizationService.Get(organizationId);
            var authSettings = organization.Settings.FirstOrDefault(x => x.Id == authSettingsId);

            if (authSettings == null)
                throw new BadHttpRequestException("No AuthSettings found");

            var result = new JWTAuthSettingsResponse()
            {
                Issuer = authSettings.Issuer,
                Audience = authSettings.Audience,
                Key = authSettings.Key
            };

            return new OkObjectResult(new ApiResponse<JWTAuthSettingsResponse>()
            {
                Data = result,
                Success = true,
                SuccessMessage = "Successfully verified user email"
            });
        }
    }
}
