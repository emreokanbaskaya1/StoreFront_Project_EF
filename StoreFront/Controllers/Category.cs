using Microsoft.AspNetCore.Mvc;

namespace StoreFront.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
