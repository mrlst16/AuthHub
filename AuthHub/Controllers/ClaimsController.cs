using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthHub.Api.Attributes;
using AuthHub.Api.Helpers;
using AuthHub.Interfaces.Claims;
using AuthHub.Models.Requests;
using AuthHub.Models.Requests.Claims;
using AuthHub.Models.Responses.Claims;
using Common.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    [Authorize]
    [Route("api/claims")]
    [ApiController]
    public class ClaimsController : Controller
    {
        private readonly IClaimsService _service;

        public ClaimsController(
            IClaimsService service
            )
        {
            _service = service;
        }

        [HttpPost("set")]
        public async Task<IActionResult> AddClaims(
            [FromBody] SetClaimsRequest request
            )
        {
            await _service.SetClaims(
                request.UserId, 
                request.Claims.ToDictionary(x => x.Key, y => y.Value)
            );
            
            var response = new ApiResponse<bool>()
            {
                Data = true,
                Success = true,
                SuccessMessage = "Successfully added claim to user"
            };
            return new OkObjectResult(response);
        }

        [HttpGet("template")]
        public async Task<IActionResult> GetTemplateByNameAsync(
            [FromQuery] string name
        )
        {
            return new OkObjectResult(new ApiResponse<ClaimsTemplateResponse>()
            {
                Data = await _service.GetClaimsTemplateAsync(User.GetOrganizationId(), name)
            });
        }

        [HttpPost("template")]
        public async Task<IActionResult> AddClaimsTemplateAsync(
            [FromBody] AddClaimsTemplateRequest request
        )
        {
            return new OkObjectResult(new ApiResponse<int?>()
            {
                Data = await _service.AddClaimsTemplateAsync(User.GetOrganizationId(), request.Name, request.Description, request.Keys)
            });
        }

        [HttpGet("list_templates")]
        public async Task<IActionResult> GetListTemplatesAsync()
        {
            return new OkObjectResult(new ApiResponse<IEnumerable<ClaimsTemplateListItem>>()
            {
                Data = await _service.GetClaimsTemplateListAsync(User.GetOrganizationId())
            });
        }
    }
}