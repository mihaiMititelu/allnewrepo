using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UniFIIcation.Models;

namespace UniFIIcation.Controllers.Api
{
    public class ApiController : Controller
    {
        private readonly FIIContext _context = new FIIContext();

        [HttpGet("api/getnews")]
        public JsonResult GetNews()
        {
            return Json(_context.Announcements.ToList());
        }

    }
}