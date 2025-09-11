using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFront.Context;

namespace StoreFront.ViewComponents
{
    public class _DailySalesDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
