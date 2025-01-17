using Microsoft.AspNetCore.Mvc;

namespace Movies.WebUI.Controllers
{
    public class AdminTemplateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }
    }
}
