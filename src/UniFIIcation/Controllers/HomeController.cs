using Microsoft.AspNetCore.Mvc;
using UniFIIcation.Models;

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
            return View();
        }

        public IActionResult Materii()
        {
            return View();
        }
    }
}
