using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UniFIIcation.Models
{
    public class AnnouncementSeedData
    {
        private readonly FIIContext _context;
        private UserManager<User> _manager;


        public AnnouncementSeedData(FIIContext context, UserManager<User> manager)
        {
            _context = context;
            _manager = manager;
        }

        public async Task EnsureSeedData()
        {
            for (var i = 0; i < 10; i++)
            {
                _context.Announcements.Add(new Announcement()
                {
                    PublishDate = DateTime.Now,
                    Title = "Lorem ipsum",
                    TextContent =
                    "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum.",
                    Author = "Mihai Mititelu"
                });
            }
            await _context.SaveChangesAsync();
        }
    }
}