using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using AuthHub.ServiceRegistrations;
using CommonCore.Models.Responses;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("create_user")]
        public async Task<IActionResult> CreateUser(
            [FromBody] UserRequest request
            )
        {
            _validatorFactory.ValidateAndThrow<UserRequest>(request);

            var response = new ApiResponse<User>()
            {
                Data = await _service.CreateUser(request),
                SuccessMessage = "Sucessfully created user",
                Sucess = true
            };
            return new OkObjectResult(response);
        }
    }
}
