using System;
using Microsoft.AspNetCore.Mvc;
using UniFIIcation.Models;

namespace UniFIIcation.Controllers
{
    public class AddNewsController : Controller
    {
        private readonly FIIContext _context;

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
            announcement.Author = "eu";
            announcement.PublishDate = DateTime.Now;

            _context.Announcements.Add(announcement);
            _context.SaveChanges();
            ModelState.Clear();
            return View();
        }
    }
}