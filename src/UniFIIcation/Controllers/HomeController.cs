using Microsoft.AspNetCore.Mvc;
using UniFIIcation.Models;

namespace UniFIIcation.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home
        public void /*JsonResult*/ AllNews()
        {
            using (FIIContext ctx = new FIIContext())
            {
                //TODO: ia date din baza de date                
            }
        }

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
