using Microsoft.AspNetCore.Mvc;

namespace Movies.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
