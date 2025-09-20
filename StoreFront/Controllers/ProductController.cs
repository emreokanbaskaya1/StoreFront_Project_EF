using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFront.Context;
using StoreFront.Entities;

namespace StoreFront.Controllers
{
    public class ProductController(StoreContext _context) : Controller
    {
        public IActionResult ProductList()
        {
            var items = _context.Products.Include(x=>x.Category).ToList();
            return View(items);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            var categories = _context.Categories
                                     .Select(c => new SelectListItem
                                     {
                                         Value = c.CategoryId.ToString(),
                                         Text = c.CategoryName
                                     }).ToList();
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product) { 
        
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = _context.Products.Find(id);
            var categories = _context.Categories
                                         .Select(c => new SelectListItem
                                         {
                                             Value = c.CategoryId.ToString(),
                                             Text = c.CategoryName
                                         }).ToList();
            ViewBag.categories = categories;
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product) { 
        
        _context.Products.Update(product);
            _context.SaveChanges();

            
            return RedirectToAction("ProductList");
        }

    }
}
