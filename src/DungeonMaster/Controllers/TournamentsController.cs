using Microsoft.AspNetCore.Mvc;


namespace DungeonMaster.Controllers
{
    public class TournamentsController : Controller
    {
        // GET: /<controller>/
        public IActionResult New()
        {
            return View();
        }
    }
}
