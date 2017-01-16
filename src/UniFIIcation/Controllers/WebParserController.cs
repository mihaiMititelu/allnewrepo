using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Welcome([FromServices] IMyParseWeb web)
        {
            ViewData["header"] = new List<string>();
            ViewData["rows"] = new List<string>();
            ViewData["start"] = 0;

            try
            {
                string[] lines = System.IO.File.ReadAllLines("sites.txt");
                ViewData["orar"] = web.ExtractOptions(lines[0]);
                ViewData["profesori"] = web.ExtractOptions(lines[1]);
            }
            catch (Exception ex)
            {
                string except = new ParseWeb().ParseException(ex.ToString());
                ViewData["orar"] = web.ExtractOptions(except);
                ViewData["profesori"] = web.ExtractOptions(except);
            }
            return View();
        }

        public IActionResult ParserPage([FromServices] IMyParseWeb web, string url)
        {
            var computed = web.ExtractContent(url);
            List<string> lst = new List<string>();
            List<string> lst2 = new List<string>();
            int startFrom = 8;
            if (computed.Count != 1)
            {
                for (int i = 0; i < 9; ++i)
                {
                    if (computed[i].Contains("Grupa"))
                    {
                        startFrom = 9;
                        break;
                    }
                }

                for (int i = 0; i < startFrom; ++i)
                {
                    lst.Add(computed[i]);
                }

                for (int i = 0; i < startFrom; ++i)
                {
                    int a = lst.FindIndex(startFrom, x => x.Equals(lst[i]));
                    if (a > 0)
                    {
                        lst.RemoveAt(a);
                    }
                }

                //--------------------------
                for (int i = startFrom; i < computed.Count(); ++i)
                {
                    lst2.Add(computed[i]);
                }
                List<string> days = new List<string> { "Luni", "Marti", "Miercuri", "Joi", "Vineri", "Sambata", "Duminica" };
                foreach (var day in days)
                {
                    if (lst2.Where(e => e.Contains(day)).Count() > 1)
                    {
                        int p = lst2.FindIndex(lst2.FindIndex(x => x.Contains(day)) + 1, x => x.Contains(day));
                        lst2.RemoveRange(p, lst2.Count - p);
                        break;
                    }
                }
            }
            else
            {
                startFrom = 0;
                lst = computed.ToList<string>();
                lst2 = computed.ToList<string>();
            }
            //ViewData["header1"] = lst;

            //ViewBag.MyMessage = $"Result\n{a}";

            ViewData["header"] = lst;
            ViewData["rows"] = lst2;
            ViewData["start"] = startFrom;

            try
            {
                string[] lines = System.IO.File.ReadAllLines("sites.txt");
                ViewData["orar"] = web.ExtractOptions(lines[0]);
                ViewData["profesori"] = web.ExtractOptions(lines[1]);
            }
            catch (Exception ex)
            {
                string except = new ParseWeb().ParseException(ex.ToString());
                ViewData["orar"] = web.ExtractOptions(except);
                ViewData["profesori"] = web.ExtractOptions(except);
            }
            return View();
        }
    }
}
