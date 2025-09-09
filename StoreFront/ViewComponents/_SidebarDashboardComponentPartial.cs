using Microsoft.AspNetCore.Mvc;

namespace StoreFront.ViewComponents
{
    public class _SidebarDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
