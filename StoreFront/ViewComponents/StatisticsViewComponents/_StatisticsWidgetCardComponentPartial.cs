using Microsoft.AspNetCore.Mvc;
using StoreFront.Context;

namespace StoreFront.ViewComponents.StatisticsViewComponents
{
    public class _StatisticsWidgetCardComponentPartial(StoreContext context) : ViewComponent
    {
        private readonly StoreContext _context = context;

        public IViewComponentResult Invoke()
        {
            ViewBag.CategoryCount = _context.Categories.Count();

            ViewBag.MaxProductPrice = _context.Products.Max(x => x.ProductPrice);

            ViewBag.MinProductPrice = _context.Products.Min(x => x.ProductPrice);

            ViewBag.productMaxPriceProductName = _context.Products.Where(x => x.ProductPrice == (_context.Products.Max(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();

            ViewBag.productMinPriceProductName = _context.Products.Where(x => x.ProductPrice == (_context.Products.Min(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();

            ViewBag.totalSumProductStock = _context.Products.Sum(x => x.ProductStock);

            ViewBag.averageProductStock = _context.Products.Average(x => x.ProductStock);

            ViewBag.averageProductPrice = _context.Products.Average(x => x.ProductPrice).ToString("00.00");

            ViewBag.biggerPriceThan1000ProductCount = _context.Products.Where(x => x.ProductPrice > 1000).Count();

            ViewBag.GetIdis4ProductName = _context.Products.Where(x=>x.ProductId == 4 ).Select(y => y.ProductName).FirstOrDefault();

            ViewBag.StockBetween50to100ProductCount = _context.Products.Where(x => x.ProductStock > 50 && x.ProductStock < 100).Count();
           
            return View();
        }
    }
}
