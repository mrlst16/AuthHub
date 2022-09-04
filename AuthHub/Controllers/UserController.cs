using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using FluentValidation;

namespace AuthHub.Controllers
{
    [ApiController]
    [Route("api/user")]
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

        [HttpPatch("save")]
        public async Task<IActionResult> CreateUser(
            [FromBody] CreateUserRequest request
            )
        {
            await _validator.ValidateAndThrowAsync(request);
            await _service.CreateAsync(request);
            var response = new ApiResponse<bool>()
            {
                Data = true,
                SuccessMessage = "Successfully created user",
                Sucess = true
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
                    Sucess = false,
                    FailureMessage = "No Id was passed"
                });

            var response = new ApiResponse<User>()
            {
                Data = await _service.ReadAsync(id),
                SuccessMessage = "Successfully created user",
                Sucess = true
            };
            return new OkObjectResult(response);
        }
    }
}
