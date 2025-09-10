using Microsoft.AspNetCore.Mvc;

namespace StoreFront.ViewComponents
{
    public class _ChartDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
