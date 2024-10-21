using System.Threading.Tasks;
using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Requests;
using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _service;

        [HttpPost("create")]
        public async Task<IActionResult> AddAsync(
            [FromBody] CreateOrganizationRequest request
            )
        {
            return new OkObjectResult(new ApiResponse<Organization>()
            {
                Data = await _service.CreateAsync(request)
            });
        }
    }
}
