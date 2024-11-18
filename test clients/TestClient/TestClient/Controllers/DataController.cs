using Microsoft.AspNetCore.Mvc;

namespace TestClient.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
