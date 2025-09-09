using Microsoft.AspNetCore.Mvc;

namespace StoreFront.ViewComponents
{
    public class _RightSidebarDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
