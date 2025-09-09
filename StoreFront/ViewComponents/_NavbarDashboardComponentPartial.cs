using Microsoft.AspNetCore.Mvc;

namespace StoreFront.ViewComponents
{
    public class _NavbarDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
