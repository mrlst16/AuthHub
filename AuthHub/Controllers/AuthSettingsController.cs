using AuthHub.Api.Attributes;
using AuthHub.Api.Helpers;
using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Responses.AuthSettings;
using Common.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Models.Requests.AuthSettings;

namespace AuthHub.Api.Controllers
{
    [ApiController]
    [Route("api/auth-settings")]
    public class AuthSettingsController : Controller
    {
        private readonly IOrganizationService _organizationService;
        private readonly IAuthSettingsService _service;

        public AuthSettingsController(
            IOrganizationService organizationService,
            IAuthSettingsService service
            )
        {
            _organizationService = organizationService;
            _service = service;
        }

        //11/9/24: This was actually a cool concept that I had, making the auth settings available
        //In an API call for the client instead of forcing the client to store the auth settings locally
        //I will keep this here for now, and create another method for getting the auth settings for use
        //in the UI
        [APICredentials]
        [HttpGet("my_auth_settings")]
        public async Task<IActionResult> GetAuthSettings(
            [FromQuery] int authSettingsId
            )
        {
            if (authSettingsId == null || authSettingsId <= 0)
                throw new BadHttpRequestException("AuthSettingsId must be provided");

            var organizationId = User.GetOrganizationId();

            var organization = await _organizationService.GetAsync(organizationId);
            var authSettings = organization.Settings;

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

        [HttpGet]
        public async Task<IActionResult> GetAuthSettingsAsync()
        {
            return new OkObjectResult(new ApiResponse<AuthSettingsResponse>()
            {
                Data = await _service.GetAuthSettingsAsync(User.GetOrganizationId())
            });
        }

        [HttpPatch]
        public async Task<IActionResult> SaveAuthSettingsAsync(
            [FromBody] AuthSettingsRequest request
            )
        {
            return new OkObjectResult(new ApiResponse<bool>()
            {
                Data = await _service.SaveAuthSettings(User.GetOrganizationId(), request)
            });
        }
    }
}