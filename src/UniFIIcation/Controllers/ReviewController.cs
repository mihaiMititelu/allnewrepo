using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewWebSite.Models;
using UniFIIcation.Models;
using System.Linq;

namespace ReviewWebSite.Controllers
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

        // GET: ReviewModels/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Comment,DateTime,Email,Name,Rating")] ReviewModel reviewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reviewModel);
        }

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
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(reviewModel);
        }

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
