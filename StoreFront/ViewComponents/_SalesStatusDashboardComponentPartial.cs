using Microsoft.AspNetCore.Mvc;

namespace StoreFront.ViewComponents
{
    public class _SalesStatusDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
