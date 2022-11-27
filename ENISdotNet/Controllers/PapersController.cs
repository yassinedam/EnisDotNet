using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ENISdotNet;
using ENISdotNet.Models;

namespace ENISdotNet.Controllers
{
    public class PapersController : Controller
    {
        private readonly ENISContext _context;

        public PapersController(ENISContext context)
        {
            _context = context;
        }

        // GET: Papers
        public async Task<IActionResult> Index()
        {
              return View(await _context.papers.ToListAsync());
        }

        // GET: Papers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.papers == null)
            {
                return NotFound();
            }

            var paper = await _context.papers
                .FirstOrDefaultAsync(m => m.paperId == id);
            if (paper == null)
            {
                return NotFound();
            }

            return View(paper);
        }

        // GET: Papers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Papers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("paperId,Type,Staus,demanded_at,approved_at")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paper);
        }

        // GET: Papers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.papers == null)
            {
                return NotFound();
            }

            var paper = await _context.papers.FindAsync(id);
            if (paper == null)
            {
                return NotFound();
            }
            return View(paper);
        }

        // POST: Papers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("paperId,Type,Staus,demanded_at,approved_at")] Paper paper)
        {
            if (id != paper.paperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaperExists(paper.paperId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paper);
        }

        // GET: Papers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.papers == null)
            {
                return NotFound();
            }

            var paper = await _context.papers
                .FirstOrDefaultAsync(m => m.paperId == id);
            if (paper == null)
            {
                return NotFound();
            }

            return View(paper);
        }

        // POST: Papers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.papers == null)
            {
                return Problem("Entity set 'ENISContext.papers'  is null.");
            }
            var paper = await _context.papers.FindAsync(id);
            if (paper != null)
            {
                _context.papers.Remove(paper);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaperExists(int id)
        {
          return _context.papers.Any(e => e.paperId == id);
        }
    }
}
