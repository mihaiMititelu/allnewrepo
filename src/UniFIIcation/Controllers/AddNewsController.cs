using System;
using Microsoft.AspNetCore.Mvc;
using UniFIIcation.Models;

namespace UniFIIcation.Controllers
{
    public class AddNewsController : Controller
    {
        private FIIContext _context;

        public AddNewsController(FIIContext context)
        {
            _context = context;
        }

        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNews(Announcement announcement)
        {
            announcement.Author = User.Identity.Name;
            announcement.PublishDate = DateTime.Now;

            _context.Announcements.Add(announcement);
            _context.SaveChanges();

            return View();
        }
    }
}