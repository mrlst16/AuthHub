using AuthHub.Api.ServiceRegistrations;
using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Organizations;
using AuthHub.Models.Requests;
using Common.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Controllers
{
    [Route("api/organization")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
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
            await _validatorFactory.GetValidator<Organization>().ValidateAndThrowAsync(request);

            var response = new ApiResponse<Organization>()
            {
                Data = await _service.Create(request),
                SuccessMessage = "Successfully created organization",
                Success = true
            };
            return new OkObjectResult(response);
        }

        [HttpPut("save_organization")]
        public async Task<IActionResult> UpdateOrganization(
            [FromBody] Organization request
            )
        {
            await _validatorFactory.GetValidator<Organization>().ValidateAndThrowAsync(request);
            var result = await _service.Update(request);
            var response = new ApiResponse<Organization>()
            {
                Data = result.Item2,
                Success = result.Item1,
                SuccessMessage = "Successfully saved organization"
            };
            return new OkObjectResult(response);
        }

        [HttpPut("save_auth_settings")]
        public async Task<IActionResult> MergeAuthSettings(
            [FromBody] AuthSettings request,
            [FromHeader] Guid organizationId
            )
        {
            await _validatorFactory.GetValidator<AuthSettings>().ValidateAndThrowAsync(request);
            var result = await _service.UpdateSettings(organizationId, request);
            var response = new ApiResponse<AuthSettings>()
            {
                Data = result.Item2,
                Success = result.Item1,
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
                    Success = false,
                    FailureMessage = "No organizationId was passed"
                });

            var result = await _service.Get(organizationId);

            var response = new ApiResponse<Organization>()
            {
                Data = result,
                Success = true,
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
                    Success = false,
                    FailureMessage = "No organizationId and/or name was passed"
                });

            var result = await _service.GetSettings(organizationId, name);

            var response = new ApiResponse<AuthSettings>()
            {
                Data = result,
                Success = true,
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
                return new BadRequestObjectResult(new ApiResponse<bool>()
                {
                    Data = false,
                    Success = false,
                    FailureMessage = "No organizationId and/or name was passed"
                });

            var result = await _service.GetSettings(organizationId, name);

            var response = new ApiResponse<AuthSettings>()
            {
                Data = result,
                Success = true,
                SuccessMessage = "Successfully retrieved organization"
            };
            return new OkObjectResult(response);
        }


    }
}
