using System.Threading.Tasks;
using AuthHub.Api.Helpers;
using AuthHub.Interfaces.APIKeys;
using AuthHub.Models.Responses.ApiKeys;
using Common.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    [Route("api/api-key")]
    [Authorize]
    [ApiController]
    public class ApiKeyController : Controller
    {
        private readonly IAPIKeyService _service;
        public ApiKeyController(
            IAPIKeyService service
            )
        {
            _service = service;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateAsync()
        {
            return new OkObjectResult(new ApiResponse<ApiKeyResponse>()
            {
                Data = await _service.GenerateApiKeyAndSecretAsync(User.GetOrganizationId())
            });
        }
    }
}