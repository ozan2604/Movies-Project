using Microsoft.AspNetCore.Mvc;

namespace Movies.WebUI.ViewComponents.AdminDashboard
{
    public class StatisticDashboard2 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //ViewBag.v1 = context.Portfolios.Count();
            //ViewBag.v2 = context.Messages.Count();
            //ViewBag.v3 = context.Services.Count();
            return View();
        }
    }
}
