using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFront.Context;

namespace StoreFront.ViewComponents
{
    public class _SalesDataDashboardComponentPartial(StoreContext _context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var items = _context.Orders.OrderByDescending(z=>z.OrderId).Include(x => x.Customer).Include(y=>y.Product).Take(5).ToList();
            return View(items);
        }
    }
}
