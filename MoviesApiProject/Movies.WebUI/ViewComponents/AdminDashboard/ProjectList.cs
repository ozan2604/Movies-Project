using Microsoft.AspNetCore.Mvc;

namespace Movies.WebUI.ViewComponents.AdminDashboard
{

    public class ProjectList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
