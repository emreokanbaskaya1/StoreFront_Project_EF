using Microsoft.AspNetCore.Mvc;

namespace StoreFront.ViewComponents
{
    public class _HeadDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
