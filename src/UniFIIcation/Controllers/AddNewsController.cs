using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UniFIIcation.Models;

namespace UniFIIcation.Controllers
{
    public class AddNewsController : Controller
    {
        public IActionResult AddNews()
        {
            return View();
        }
    }
}
