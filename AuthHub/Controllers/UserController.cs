using AuthHub.Api.Attributes;
using AuthHub.Api.Helpers;
using AuthHub.Api.Responses;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Entities.Users;
using AuthHub.Models.Requests;
using Common.Interfaces.Utilities;
using Common.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthHub.Models.Responses;

namespace AuthHub.Api.Controllers
{
    [APICredentials]
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IValidator<CreateUserRequest> _validator;
        private readonly IUserService _service;
        private readonly IMapper<User, UserResponse> _userResponseMapper;

        public UserController(
            IValidator<CreateUserRequest> validator,
            IUserService service,
            IMapper<User, UserResponse> userResponseMapper
            )
        {
            _validator = validator;
            _service = service;
            _userResponseMapper = userResponseMapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            await _validator.ValidateAndThrowAsync(request);
            var result = await _service.CreateAsync(request);

            var response = new ApiResponse<UserResponse>()
            {
                Data = _userResponseMapper.Map(result),
                SuccessMessage = "Successfully created user",
                Success = true
            };
            return new OkObjectResult(response);
        }

        [HttpGet("request_email_verification_code")]
        public async Task<IActionResult> RequestEmailVerificationCode(
            [FromBody] CreateUserRequest request
            )
        {
            var userid = User.GetUserId();
            await _service.SendEmailVerificationEmail(userid);

            var response = new ApiResponse<bool>()
            {
                Data = true,
                SuccessMessage = "Successfully created user",
                Success = true
            };
            return new OkObjectResult(response);
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(
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
                SuccessMessage = "Successfully retrieved user",
                Success = true
            };
            return new OkObjectResult(response);
        }
    }
}
