using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniFIIcation.Models
{
    public class AnnouncementSeedData
    {
        private FIIContext _context;

        public AnnouncementSeedData(FIIContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Announcements.Any())
            {
                var xmasNews = new Announcement()
                {
                    PublishDate = DateTime.Now,
                    Title = "Nu se fac ore de Craciun",
                    TextContent = "aufauisfgasufgauigfafi",
                    Author = "eu"
                };
                var xmasNews2 = new Announcement()
                {
                    PublishDate = DateTime.Now,
                    Title = "Nu se fac ore de Craciun",
                    TextContent = "aaasfsafaufgauigfafi",
                    Author = "eu"
                };
                var xmasNews3 = new Announcement()
                {
                    PublishDate = DateTime.Now,
                    Title = "Nu se fac ore de Craciun",
                    TextContent = "aufauiafasfasfasgasufgauigfafi",
                    Author = "eu"
                };
                _context.Announcements.Add(xmasNews);
                _context.Announcements.Add(xmasNews2);
                _context.Announcements.Add(xmasNews3);
                await _context.SaveChangesAsync();
            }
        }
    }
}
