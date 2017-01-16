using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UniFIIcation.Models
{
    public class AnnouncementSeedData
    {
        private readonly FIIContext _context;

        public AnnouncementSeedData(FIIContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
           
                var xmasNews = new Announcement
                {
                    PublishDate = DateTime.Now,
                    Title = "Nu se fac ore de Craciun",
                    TextContent = "aufauisfgasufgauigfafi",
                    Author = "eu"
                };
                var xmasNews2 = new Announcement
                {
                    PublishDate = DateTime.Now,
                    Title = "Nu se fac ore de Craciun",
                    TextContent = "aaasfsafaufgauigfafi",
                    Author = "eu"
                };
                var xmasNews3 = new Announcement
                {
                    PublishDate = DateTime.Now,
                    Title = "Nu se fac ore de Craciun",
                    TextContent = "aufauiafasfasfasgasufgauigfafi",
                    Author = "eu"
                };
                var xmasNews4 = new Announcement
                {
                    PublishDate = DateTime.Now,
                    Title = "Nu se fac ore de Craciun",
                    TextContent = "aufauisfgasufgauigfafi",
                    Author = "eu"
                };
                var xmasNews5 = new Announcement
                {
                    PublishDate = DateTime.Now,
                    Title = "Nu se fac ore de Craciun",
                    TextContent = "aufauisfgasufgauigfafi",
                    Author = "eu"
                };
                var xmasNews6 = new Announcement
                {
                    PublishDate = DateTime.Now,
                    Title = "Nu se fac ore de Craciun",
                    TextContent = "aufauisfgasufgauigfafi",
                    Author = "eu"
                };
                var xmasNews7 = new Announcement
                {
                    PublishDate = DateTime.Now,
                    Title = "Nu se fac ore de Craciun",
                    TextContent = "aufauisfgasufgauigfafi",
                    Author = "eu"
                };
                var xmasNews8 = new Announcement
                {
                    PublishDate = DateTime.Now,
                    Title = "Nu se fac ore de Craciun",
                    TextContent = "aufauisfgasufgauigfafi",
                    Author = "eu"
                };
                var xmasNews9 = new Announcement
                {
                    PublishDate = DateTime.Now,
                    Title = "Nu se fac ore de Craciun",
                    TextContent = "aufauisfgasufgauigfafi",
                    Author = "eu"
                };
                _context.Announcements.Add(xmasNews);
                _context.Announcements.Add(xmasNews2);
                _context.Announcements.Add(xmasNews3);
                _context.Announcements.Add(xmasNews4);
                _context.Announcements.Add(xmasNews5);
                _context.Announcements.Add(xmasNews6);
                _context.Announcements.Add(xmasNews7);
                _context.Announcements.Add(xmasNews8);
                _context.Announcements.Add(xmasNews9);
                await _context.SaveChangesAsync();
            
        }

        public async Task AddRoles()
        {
            var stud = "Student";
            var prof = "Professor";

            var studentRole = new IdentityRole(stud);
            var professorRole = new IdentityRole(prof);
            _context.Roles.Add(studentRole);
            _context.Roles.Add(professorRole);
            await _context.SaveChangesAsync();
        }
    }
}