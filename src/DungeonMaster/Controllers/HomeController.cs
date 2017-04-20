using Microsoft.AspNetCore.Mvc;

namespace DungeonMaster.Controllers
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