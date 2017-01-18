using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniFIIcation.Models;

namespace UniFIIcation.Controllers
{
    public class PostariController : Controller
    {
        private readonly FIIContext _context;
        private readonly IHostingEnvironment _appEnvironment;

        public PostariController(FIIContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }


        public IActionResult Index(int? id)
        {
            var model = new PostariViewModel();

            if (id == null)
            {
                return View(model);
            }
            //ia toate postarile
            foreach (var m in _context.Postari)
            {
                if (m.MaterieId == id)
                {
                    model.VmPostari.Add(m);
                }
            }
            //ia toate uploads-urile
            foreach (var m in _context.Uploads)
            {
                if (m.MaterieId == id)
                {
                    model.VmUploads.Add(m);
                }
            }
            //ia numele si id din materii
            foreach (var m in _context.Materii)
            {
                if (m.MaterieId == id)
                {
                    model.NumeMaterie = m.Name;
                    model.MaterieId = m.MaterieId;
                }
            }
            model.VmPostari.Sort((x, y) => y.DateTime.CompareTo(x.DateTime));
            return View(model);
        }

        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            //else            
            var postareNoua = new Postare
            {
                MaterieId = (int) id,
                PostareId = Guid.NewGuid()
            };

            return View(postareNoua);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Postare postare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postare);
                await _context.SaveChangesAsync();
                return RedirectToAction("/Index/" + postare.MaterieId);
            }

            return postare.MaterieId != 0 ? RedirectToAction("Create/" + postare.MaterieId) : RedirectToAction("Index");
        }

        //CRUD
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            foreach (var var in _context.Postari)
            {
                if (var.PostareId == id)
                    return View(var);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Postare postare)
        {
            try
            {
                _context.Update(postare);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                {
                }
                throw;
            }
            if (postare.MaterieId != 0)
                return RedirectToAction("/Index/" + postare.MaterieId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            var matId = 0;
            if (id == null)
            {
                return NotFound();
            }
            var postareDeSters = new Postare();
            foreach (var var in _context.Postari)
            {
                if (var.PostareId != id) continue;
                matId = var.MaterieId;
                postareDeSters = var;
            }
            _context.Postari.Remove(postareDeSters);
            await _context.SaveChangesAsync();

            return matId != 0 ? RedirectToAction("/Index/" + matId) : RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddUpload(int materieId, IFormFile uploadedFile)
        {
            if (materieId == 0)
                return RedirectToAction("Index");
            if (uploadedFile == null) return RedirectToAction("/Index/" + materieId);
            // путь к папке Files
            var path = "/files/" + uploadedFile.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            var file = new Upload {Name = uploadedFile.FileName, Path = path, MaterieId = materieId};
            _context.Uploads.Add(file);
            _context.SaveChanges();

            return RedirectToAction("/Index/" + materieId);
        }


        public async Task<IActionResult> DeleteFile(Guid? id)
        {
            var matId = 0;
            if (id == null)
            {
                return NotFound();
            }
            var postareDeSters = new Upload();
            foreach (var var in _context.Uploads)
            {
                if (var.UploadId != id) continue;
                matId = var.MaterieId;
                postareDeSters = var;
            }
            _context.Uploads.Remove(postareDeSters);
            await _context.SaveChangesAsync();

            return matId != 0 ? RedirectToAction("/Index/" + matId) : RedirectToAction("Index");
        }
    }
}