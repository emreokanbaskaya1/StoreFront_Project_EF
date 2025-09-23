using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFront.Context;
using StoreFront.Entities;

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


        public IActionResult OrderListByStatus(string? status)
        {
            var q = _context.Orders.AsQueryable();          // 1) Ortak sorgu

            if (!string.IsNullOrEmpty(status))
            {
                q = q.Where(o => o.Status.Contains(status));  // 2) Arama varsa filtrele
            }                                                

            var values = q.ToList();                        // 3) Sonuçları al

            if (!values.Any())
            {

                ViewBag.v = "Data isn't found regarding this status"; // 4) Boşsa uyarı

            }

            // 5) Input’u doldurmak için
            return View(values);                            // 6) Tek return
        }



        public IActionResult OrderListSearch(string name, string filterType)
        {
            
            if(filterType == "start" && !string.IsNullOrEmpty(name))
            {
                var values = _context.Orders.Where(x => x.Status.StartsWith(name)).ToList();
                return View(values);
            }
            else if(filterType == "end" && !string.IsNullOrEmpty(name))
            {
                var values = _context.Orders.Where(x => x.Status.EndsWith(name)).ToList();
                return View(values);
            }
            else if(!string.IsNullOrEmpty(name)) { 
                var orderValues = _context.Orders.ToList();
                return View(orderValues);
            }
            var orderValuesFirst = _context.Orders.ToList();
            return View(orderValuesFirst);
            
        }


        public async Task<IActionResult> OrderList()
        {
            var values = await _context.Orders.Include(x => x.Product).Include(y => y.Customer).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var products =await _context.Products
                                     .Select(p => new SelectListItem
                                     {
                                         Value = p.ProductId.ToString(),
                                         Text = p.ProductName
                                     }).ToListAsync();


            var customers = await _context.Customers
                                     .Select(c => new SelectListItem
                                     {
                                         Value = c.CustomerId.ToString(),
                                         Text = c.CustomerName + " " + c.CustomerSurname
                                     }).ToListAsync();
            ViewBag.customers = customers;
            ViewBag.products = products;
            return View();
;        }

        [HttpPost]

        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.Status = "Order Received";
            order.OrderDate = DateTime.Now;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            var value = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(value);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var products = await _context.Products
                                     .Select(p => new SelectListItem
                                     {
                                         Value = p.ProductId.ToString(),
                                         Text = p.ProductName
                                     }).ToListAsync();


            var customers = await _context.Customers
                                     .Select(c => new SelectListItem
                                     {
                                         Value = c.CustomerId.ToString(),
                                         Text = c.CustomerName + " " + c.CustomerSurname
                                     }).ToListAsync();

            ViewBag.customers = customers;
            ViewBag.products = products;


            var value = await _context.Orders.FindAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }
    }

    
}
