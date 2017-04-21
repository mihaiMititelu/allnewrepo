using DungeonMaster.Models;
using Microsoft.AspNetCore.Mvc;


namespace DungeonMaster.Controllers
{
    public class CompetitionsController : Controller
    {
        // GET: /<controller>/
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Competition competition)
        {
            return View();
        }
    }
}
