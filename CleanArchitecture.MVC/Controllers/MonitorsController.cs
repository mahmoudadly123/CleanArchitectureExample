using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MVC.Controllers
{
    public class MonitorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
