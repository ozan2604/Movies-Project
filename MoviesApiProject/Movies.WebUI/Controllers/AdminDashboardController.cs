using Microsoft.AspNetCore.Mvc;

namespace Movies.WebUI.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult DashboardPage()
        {
            return View();
        }
    }
}
