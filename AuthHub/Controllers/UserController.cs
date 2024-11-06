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
using AuthHub.Models.Responses.User;

namespace AuthHub.Api.Controllers
{
    [APICredentials]
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IValidator<CreateUserRequest> _validator;
        private readonly IUserService _service;
        private readonly IMapper<User, UserIdResponse> _userResponseMapper;

        public UserController(
            IValidator<CreateUserRequest> validator,
            IUserService service,
            IMapper<User, UserIdResponse> userResponseMapper
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
            var result = await _service.CreateAsync(User.GetOrganizationId(), request);

            var response = new ApiResponse<UserIdResponse>()
            {
                Data = _userResponseMapper.Map(result),
                SuccessMessage = "Successfully created user",
                Success = true
            };
            return new OkObjectResult(response);
        }

        [HttpGet("request_email_verification_code")]
        public async Task<IActionResult> RequestEmailVerificationCodeAsync(
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

        [HttpGet]
        public async Task<IActionResult> GetAsync(
           [FromQuery] int userId
           )
        {
            if (userId <= 0)
                return new BadRequestObjectResult(new ApiResponse<bool>()
                {
                    Data = false,
                    Success = false,
                    FailureMessage = "No Id was passed"
                });

            var response = new ApiResponse<UserResponse>()
            {
                Data = await _service.ReadAsync(userId),
                SuccessMessage = "Successfully retrieved user",
                Success = true
            };
            return new OkObjectResult(response);
        }
    }
}
