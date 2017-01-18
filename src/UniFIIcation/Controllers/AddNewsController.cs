using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniFIIcation.Models;

namespace UniFIIcation.Controllers
{
    public class AddNewsController : Controller
    {
        private readonly FIIContext _context;
        private readonly UserManager<User> _manager;


        public AddNewsController(FIIContext context, UserManager<User> manager)
        {
            _context = context;
            _manager = manager;

        }

        [Authorize]
        public IActionResult AddNews()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddNews(Announcement announcement)
        {
            var author = await _manager.FindByNameAsync(User.Identity.Name);
            announcement.Author = author.Prenume + " " + author.Nume;
            announcement.PublishDate = DateTime.Now;

            _context.Announcements.Add(announcement);
            _context.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}