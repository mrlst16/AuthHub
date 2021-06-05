using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Organizations;
using AuthHub.ServiceRegistrations;
using CommonCore.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AuthHub.Controllers
{
    [Route("api")]
    public class OrganizationController : Controller
    {
        private readonly IValidatorFactory _validatorFactory;
        private readonly IOrganizationService _service;

        public OrganizationController(
            IValidatorFactory validatorFactory,
            IOrganizationService service
            )
        {
            _validatorFactory = validatorFactory;
            _service = service;
        }

        [HttpPost("create_organization")]
        public async Task<IActionResult> CreateOrganization(
            [FromBody] CreateOrganizationRequest request
            )
        {
            _validatorFactory.ValidateAndThrow<CreateOrganizationRequest>(request);
            var response = new ApiResponse<Organization>()
            {
                Data = await _service.Create(request),
                SuccessMessage = "Successfully created organization",
                Sucess = true
            };
            return new OkObjectResult(response);
        }

        [HttpPost("update_organization")]
        public async Task<IActionResult> UpdateOrganization(
            [FromBody] Organization request
            )
        {
            _validatorFactory.ValidateAndThrow<Organization>(request);
            var result = await _service.Update(request);
            var response = new ApiResponse<Organization>()
            {
                Data = result.Item2,
                Sucess = result.Item1,
                SuccessMessage = "Successfully updated organization"
            };
            return new OkObjectResult(response);
        }

        [HttpPost("update_organization_settings")]
        public async Task<IActionResult> UpdateOrganizationSettiings(
            [FromBody] OrganizationSettings request,
            [FromQuery] Guid organizationId
            )
        {
            _validatorFactory.ValidateAndThrow<OrganizationSettings>(request);
            var result = await _service.UpdateSettings(organizationId, request);
            var response = new ApiResponse<OrganizationSettings>()
            {
                Data = result.Item2,
                Sucess = result.Item1,
                SuccessMessage = "Successfully updated organization settings"
            };
            return new OkObjectResult(response);
        }
    }
}
