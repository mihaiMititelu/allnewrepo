using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UniFIIcation.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UniFIIcation.Controllers
{
    public class WebParserController : Controller
    {
        public WebParserController(IMyParseWeb web)
        {
        }

        //http://localhost:23620/text/extract?spec=a&input=Anamaria
        //WebParser/ParserPage?url=http://profs.info.uaic.ro/~orar/participanti/orar_I3B3.html   
        // GET: /<controller>/
        public IActionResult Welcome([FromServices] IMyParseWeb web)
        {
            //ViewData["header"] = new List<string>();
            //ViewData["rows"] = new List<string>();
            //ViewData["start"] = 0;

            readContent(web);
            return View();
        }

        public IActionResult ParserPage([FromServices] IMyParseWeb web, string url)
        {
            var computed = web.ExtractContent(url);
            var lst = new List<string>();
            var lst2 = new List<string>();
            var startFrom = 8;
            if (computed.Count != 1)
            {
                for (var i = 0; i < 9; ++i)
                    if (computed[i].Contains("Grupa"))
                    {
                        startFrom = 9;
                        break;
                    }

                for (var i = 0; i < startFrom; ++i)
                    lst.Add(computed[i]);

                for (var i = 0; i < startFrom; ++i)
                {
                    var a = lst.FindIndex(startFrom, x => x.Equals(lst[i]));
                    if (a > 0)
                        lst.RemoveAt(a);
                }

                //--------------------------
                for (var i = startFrom; i < computed.Count(); ++i)
                    lst2.Add(computed[i]);
                var days = new List<string> {"Luni", "Marti", "Miercuri", "Joi", "Vineri", "Sambata", "Duminica"};
                foreach (var day in days)
                    if (lst2.Count(e => e.Contains(day)) > 1)
                    {
                        var p = lst2.FindIndex(lst2.FindIndex(x => x.Contains(day)) + 1, x => x.Contains(day));
                        lst2.RemoveRange(p, lst2.Count - p);
                        break;
                    }
            }
            else
            {
                startFrom = 0;
                lst = computed.ToList();
                lst2 = computed.ToList();
            }
            //ViewData["header1"] = lst;

            //ViewBag.MyMessage = $"Result\n{a}";

            ViewData["header"] = lst;
            ViewData["rows"] = lst2;
            ViewData["start"] = startFrom;

            readContent(web);
            return View();
        }
        private void readContent(IMyParseWeb web)
        {
            try
            {
                var lines = System.IO.File.ReadAllLines("sites.txt");
                ViewData["orar"] = web.ExtractOptions(lines[0]);
                ViewData["profesori"] = web.ExtractOptions(lines[1]);
            }
            catch (Exception ex)
            {
                var except = new ParseWeb().ParseException(ex.ToString());
                ViewData["orar"] = web.ExtractOptions(except);
                ViewData["profesori"] = web.ExtractOptions(except);
            }
        }
    }
}