using Microsoft.AspNetCore.Mvc;
using StoreFront.Context;

namespace StoreFront.ViewComponents
{
    public class _ToDoDashboardComponentPartial(StoreContext _context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _context.Todos.OrderByDescending(x=>x.TodoId).Take(6).ToList();
            return View(values);
        }
    }
}
