using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using AuthHub.ServiceRegistrations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Common.Models.Responses;

namespace AuthHub.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/user")]
    public class UserController : Controller
    {
        private readonly IValidatorFactory _validatorFactory;
        private readonly IUserService _service;

        public UserController(
            IValidatorFactory validatorFactory,
            IUserService service
            )
        {
            _validatorFactory = validatorFactory;
            _service = service;
        }

        [HttpPatch("save")]
        public async Task<IActionResult> CreateUser(
            [FromBody] SaveUserRequest request
            )
        {
            _validatorFactory.ValidateAndThrow<SaveUserRequest>(request);
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
