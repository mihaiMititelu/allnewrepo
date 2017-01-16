using System;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult AddNews()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddNews(Announcement announcement)
        {
            announcement.Author = User.Identity.Name;
            announcement.PublishDate = DateTime.Now;

            _context.Announcements.Add(announcement);
            _context.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}