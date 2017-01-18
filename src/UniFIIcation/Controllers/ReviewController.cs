using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewWebSite.Models;
using UniFIIcation.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace UniFIIcation.Controllers
{
    public class ReviewController : Controller
    {
        private readonly FIIContext _context;

        public ReviewController(FIIContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Reviews.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewModel = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            if (reviewModel == null)
            {
                return NotFound();
            }

            return View(reviewModel);
        }

        // GET: ReviewModels/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Comment,DateTime,Email,Name,Rating")] ReviewModel reviewModel)
        {
            if (!ModelState.IsValid) return View(reviewModel);
            _context.Add(reviewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewModel = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            if (reviewModel == null)
            {
                return NotFound();
            }
            return View(reviewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Comment,DateTime,Email,Name,Rating")] ReviewModel reviewModel)
        {
            if (id != reviewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewModelExists(reviewModel.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(reviewModel);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewModel = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            if (reviewModel == null)
            {
                return NotFound();
            }

            return View(reviewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviewModel = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            _context.Reviews.Remove(reviewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReviewModelExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
