using Microsoft.AspNetCore.Mvc;

namespace StoreFront.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
