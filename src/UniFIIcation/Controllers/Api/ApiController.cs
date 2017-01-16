using System.Linq;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("api/getuser")]
        public JsonResult GetUser()
        {
            return Json(_context.Users.ToList());
        }
    }
}