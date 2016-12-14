using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using UniFIIcation.Models;

namespace UniFIIcation.Controllers
{
    public class MateriiController : Controller
    {

        private IHostingEnvironment _environment;
        
        public void HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        // GET: /<controller>/
        public IActionResult Materii(MateriiModel model)
        {
            var name = model.Name;
            var email = model.Email;
            var comment = model.Comment;
            ViewData["Message"] = "Mesajul mult astetat";

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Materii(ICollection<IFormFile> files)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return View();
        }
    }
} 
