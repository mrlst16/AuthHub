using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Organizations;
using AuthHub.ServiceRegistrations;
using CommonCore.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AuthHub.Controllers
{
    [Route("api/organization")]
    [ApiController]
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

        [HttpPost("merge_auth_settings")]
        public async Task<IActionResult> MergeAuthSettings(
            [FromBody] AuthSettings request,
            [FromQuery] Guid organizationId
            )
        {
            _validatorFactory.ValidateAndThrow<AuthSettings>(request);
            var result = await _service.UpdateSettings(organizationId, request);
            var response = new ApiResponse<AuthSettings>()
            {
                Data = result.Item2,
                Sucess = result.Item1,
                SuccessMessage = "Successfully updated organization settings"
            };
            return new OkObjectResult(response);
        }

        [HttpGet("get_organization")]
        public async Task<IActionResult> GetOrganization(
           [FromQuery] Guid organizationId
           )
        {
            if (organizationId == Guid.Empty)
                return new BadRequestObjectResult(new ApiResponse<bool>()
                {
                    Data = false,
                    Sucess = false,
                    FailureMessage = "No organizationId was passed"
                });

            var result = await _service.Get(organizationId);

            var response = new ApiResponse<Organization>()
            {
                Data = result,
                Sucess = true,
                SuccessMessage = "Successfully retrieved organization"
            };
            return new OkObjectResult(response);
        }


        [HttpGet("get_auth_settings")]
        public async Task<IActionResult> GetAuthSettings(
           [FromQuery] Guid organizationId,
           [FromQuery] string name
           )
        {
            if (organizationId == Guid.Empty || string.IsNullOrWhiteSpace(name))
                new BadRequestObjectResult(new ApiResponse<bool>()
                {
                    Data = false,
                    Sucess = false,
                    FailureMessage = "No organizationId and/or name was passed"
                });

            var result = await _service.GetSettings(organizationId, name);

            var response = new ApiResponse<AuthSettings>()
            {
                Data = result,
                Sucess = true,
                SuccessMessage = "Successfully retrieved organization"
            };
            return new OkObjectResult(response);
        }

        [HttpGet("organization_sign_in")]
        public async Task<IActionResult> OrganizationSignIp(
          [FromQuery] Guid organizationId,
          [FromQuery] string name
          )
        {
            if (organizationId == Guid.Empty || string.IsNullOrWhiteSpace(name))
                new BadRequestObjectResult(new ApiResponse<bool>()
                {
                    Data = false,
                    Sucess = false,
                    FailureMessage = "No organizationId and/or name was passed"
                });

            var result = await _service.GetSettings(organizationId, name);

            var response = new ApiResponse<AuthSettings>()
            {
                Data = result,
                Sucess = true,
                SuccessMessage = "Successfully retrieved organization"
            };
            return new OkObjectResult(response);
        }


    }
}
