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
    public class DepartementsController : Controller
    {
        private readonly ENISContext _context;

        public DepartementsController(ENISContext context)
        {
            _context = context;
        }

        // GET: Departements
        public async Task<IActionResult> Index()
        {
              return View(await _context.departements.ToListAsync());
        }

        // GET: Departements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.departements == null)
            {
                return NotFound();
            }

            var departement = await _context.departements
                .FirstOrDefaultAsync(m => m.DepartementId == id);
            if (departement == null)
            {
                return NotFound();
            }

            return View(departement);
        }

        // GET: Departements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartementId,spacialitée")] Departement departement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departement);
        }

        // GET: Departements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.departements == null)
            {
                return NotFound();
            }

            var departement = await _context.departements.FindAsync(id);
            if (departement == null)
            {
                return NotFound();
            }
            return View(departement);
        }

        // POST: Departements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartementId,spacialitée")] Departement departement)
        {
            if (id != departement.DepartementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartementExists(departement.DepartementId))
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
            return View(departement);
        }

        // GET: Departements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.departements == null)
            {
                return NotFound();
            }

            var departement = await _context.departements
                .FirstOrDefaultAsync(m => m.DepartementId == id);
            if (departement == null)
            {
                return NotFound();
            }

            return View(departement);
        }

        // POST: Departements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.departements == null)
            {
                return Problem("Entity set 'ENISContext.departements'  is null.");
            }
            var departement = await _context.departements.FindAsync(id);
            if (departement != null)
            {
                _context.departements.Remove(departement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartementExists(int id)
        {
          return _context.departements.Any(e => e.DepartementId == id);
        }
    }
}
