using Microsoft.AspNetCore.Mvc;

namespace UniFIIcation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Materii()
        {
            return View();
        }
    }
}