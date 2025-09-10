using Microsoft.AspNetCore.Mvc;
using StoreFront.Context;

namespace StoreFront.ViewComponents
{
    public class _ActivityDashboardComponentPartial(StoreContext _context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _context.Activities.ToList();
            return View(values);
        }
    }
}
