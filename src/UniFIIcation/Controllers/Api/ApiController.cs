using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UniFIIcation.Models;


namespace UniFIIcation.Controllers.Api
{
    public class ApiController : Controller
    {
        private readonly FIIContext _context = new FIIContext();

        [HttpGet("api/get")]
        public JsonResult Get()
        {
            return Json(_context.Announcements.ToList());
        }
    }
}
