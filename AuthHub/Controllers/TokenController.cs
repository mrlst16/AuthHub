using AuthHub.Interfaces.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    [Route("api/token")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;

        public TokenController(
            ITokenService tokenService
            )
        {
            _tokenService = tokenService;
        }

    }
}