using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.Api.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ApiResponse<Guid> response = new ApiResponse<Guid>();

            return null;
        }
    }
}
