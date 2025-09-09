using Microsoft.AspNetCore.Mvc;

namespace StoreFront.ViewComponents
{
    public class _ThemeSettingsWrapperDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
