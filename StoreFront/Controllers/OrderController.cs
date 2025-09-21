using Microsoft.AspNetCore.Mvc;
using StoreFront.Context;

namespace StoreFront.Controllers
{
    public class OrderController(StoreContext _context) : Controller
    {
        public IActionResult AllStockSmallerThan5()
        {
            bool orderStockCount = _context.Orders.All(x => x.OrderCount <= 5);

            if (orderStockCount == true)
            {
                ViewBag.v = "All orders are smaller than 5!";
            }
            else
            {
                ViewBag.v = "All orders aren't smaller than 5!";
            }

                return View();
        }
    }
}
