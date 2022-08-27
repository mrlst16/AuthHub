using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using AuthHub.ServiceRegistrations;
using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AuthHub.Controllers
{
    [Route("api/user")]
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
            [FromBody] User request
            )
        {
            _validatorFactory.ValidateAndThrow<User>(request);
            await _service.SaveAsync(request);

            var response = new ApiResponse<bool>()
            {
                Data = true,
                SuccessMessage = "Sucessfully created user",
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

            var response = new ApiResponse<UserViewModel>()
            {
                Data = await _service.GetAsync(id),
                SuccessMessage = "Sucessfully created user",
                Sucess = true
            };
            return new OkObjectResult(response);
        }
    }
}
