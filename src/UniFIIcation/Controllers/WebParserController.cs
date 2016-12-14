using Microsoft.AspNetCore.Mvc;
using UniFIIcation.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UniFIIcation.Controllers
{
    public class WebParserController : Controller
    {
        private readonly IMyParseWeb _parseService;

        public WebParserController(IMyParseWeb web)
        {
            _parseService = web;
        }
        //http://localhost:23620/text/extract?spec=a&input=Anamaria
        //WebParser/ParserPage?url=http://profs.info.uaic.ro/~orar/participanti/orar_I3B3.html      
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ParserPage([FromServices] IMyParseWeb web,string url)
        {
            var computed = web.ExtractContent(url);
            string a = string.Empty;
            foreach(var row in computed)
            {
                a += row + "\n";
            }
            ViewBag.MyMessage = $"Result\n{a}";
            return View();
        }
    }
}
