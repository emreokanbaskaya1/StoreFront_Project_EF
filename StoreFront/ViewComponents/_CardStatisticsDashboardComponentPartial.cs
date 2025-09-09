using Microsoft.AspNetCore.Mvc;
using StoreFront.Context;

namespace StoreFront.ViewComponents
{
    public class _CardStatisticsDashboardComponentPartial(StoreContext context) : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            ViewBag.totalCustomerCount = context.Customers.Count();
            ViewBag.totalCategoryCount = context.Categories.Count();
            ViewBag.totalProductCount = context.Products.Count();
            ViewBag.avgCustomerBalance = context.Customers.Average(x=>x.CustomerBalance).ToString("00.00"+" TL");
            return View();
        }
    }
}
