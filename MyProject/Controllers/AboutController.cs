using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.menuindex = 1;
            return View();
        }

    }
}
