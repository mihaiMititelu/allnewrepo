using System;
using System.Threading.Tasks;

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
                Title = "Lorem ipsum",
                TextContent =
                    "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum.",
                Author = "eu"
            };
            var xmasNews2 = new Announcement
            {
                PublishDate = DateTime.Now,
                Title = "Lorem ipsum",
                TextContent =
                    "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum.",
                Author = "eu"
            };
            var xmasNews3 = new Announcement
            {
                PublishDate = DateTime.Now,
                Title = "Lorem ipsum",
                TextContent =
                    "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum.",
                Author = "eu"
            };
            var xmasNews4 = new Announcement
            {
                PublishDate = DateTime.Now,
                Title = "Lorem ipsum",
                TextContent =
                    "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum.",
                Author = "eu"
            };
            _context.Announcements.Add(xmasNews);
            _context.Announcements.Add(xmasNews2);
            _context.Announcements.Add(xmasNews3);
            _context.Announcements.Add(xmasNews4);
            await _context.SaveChangesAsync();
        }
    }
}