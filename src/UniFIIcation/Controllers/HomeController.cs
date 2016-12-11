using Microsoft.AspNetCore.Mvc;

namespace UniFIIcation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orar()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Materii()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
