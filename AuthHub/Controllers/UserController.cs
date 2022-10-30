using System.Threading.Tasks;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using Common.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : Controller
    {
        private readonly IValidator<CreateUserRequest> _validator;
        private readonly IUserService _service;

        public UserController(
            IValidator<CreateUserRequest> validator,
            IUserService service
            )
        {
            _validator = validator;
            _service = service;
        }

        [HttpPatch("create")]
        public async Task<IActionResult> CreateUser(
            [FromBody] CreateUserRequest request
            )
        {
            await _validator.ValidateAndThrowAsync(request);
            var response = new ApiResponse<Guid>()
            {
                Data = await _service.CreateAsync(request),
                SuccessMessage = "Successfully created user",
                Success = true
            };
            return new OkObjectResult(response);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetUser(
           [FromQuery] Guid id
           )
        {
            if (id == Guid.Empty)
                return new BadRequestObjectResult(new ApiResponse<bool>()
                {
                    Data = false,
                    Success = false,
                    FailureMessage = "No Id was passed"
                });

            var response = new ApiResponse<User>()
            {
                Data = await _service.ReadAsync(id),
                SuccessMessage = "Successfully created user",
                Success = true
            };
            return new OkObjectResult(response);
        }
    }
}
