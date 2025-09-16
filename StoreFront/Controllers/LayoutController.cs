using Microsoft.AspNetCore.Mvc;

namespace StoreFront.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
