using System.Threading.Tasks;
using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Requests;
using AuthHub.Models.Tokens;
using Common.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _service;
        private readonly IValidator<CreateOrganizationRequest> _createOrganizationRequestValidator;
        
        public OrganizationController(
            IOrganizationService service,
            IValidator<CreateOrganizationRequest> createOrganizationRequestValidator
            )
        {
            _service = service;
            _createOrganizationRequestValidator = createOrganizationRequestValidator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateOrganizationRequest request
        )
        {
            await _createOrganizationRequestValidator.ValidateAndThrowAsync(request);
            return new OkObjectResult(new ApiResponse<Organization>()
            {
                Data = await _service.CreateAsync(request)
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(
            [FromBody] OrganizationLoginRequest request
        )
        {
            return new OkObjectResult(new ApiResponse<Token>()
            {
                Data = await _service.LoginAsync(request)
            });
        }
    }
}
