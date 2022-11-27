using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ENISdotNet;
using ENISdotNet.Models;
using ENISdotNet.ViewModels;

namespace ENISdotNet.Controllers
{
    public class DemandePFEsController : Controller
    {
        private readonly ENISContext _context;

        public DemandePFEsController(ENISContext context)
        {
            _context = context;
        }

        // GET: DemandePFEs
        public async Task<IActionResult> Index()
        {
              return View(await _context.demandes.ToListAsync());
        }

        // GET: DemandePFEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.demandes == null)
            {
                return NotFound();
            }

            var demandePFE = await _context.demandes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demandePFE == null)
            {
                return NotFound();
            }

            return View(demandePFE);
        }

        // GET: DemandePFEs/Create
        public async Task<IActionResult> Create()
        {
            var demandeViewModel = new DemandePfeViewModel(new DemandePFE(),await _context.Users.ToListAsync());
            return View(demandeViewModel);
        }

        // POST: DemandePFEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DemandePfeViewModel demandeViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users == null)
                {
                    return NotFound();
                }
                var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == demandeViewModel.demandePFE!.UserId);
                if (user == null)
                {
                    return NotFound();
                }
                DemandePFE demandePFE = new DemandePFE()
                {
                    date=demandeViewModel.demandePFE!.date,
                    description=demandeViewModel.demandePFE!.description,
                    Status=demandeViewModel.demandePFE!.Status,
                    demanded_at = demandeViewModel.demandePFE!.demanded_at,
                    approved_at=demandeViewModel.demandePFE!.approved_at,
                    user=user
                };
                _context.Add(demandePFE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demandeViewModel);
        }

        // GET: DemandePFEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.demandes == null)
            {
                return NotFound();
            }

            var demandePFE = await _context.demandes.FindAsync(id);
            if (demandePFE == null)
            {
                return NotFound();
            }
            return View(demandePFE);
        }

        // POST: DemandePFEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,date,description,Status,demanded_at,approved_at")] DemandePFE demandePFE)
        {
            if (id != demandePFE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demandePFE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemandePFEExists(demandePFE.Id))
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
            return View(demandePFE);
        }

        // GET: DemandePFEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.demandes == null)
            {
                return NotFound();
            }

            var demandePFE = await _context.demandes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demandePFE == null)
            {
                return NotFound();
            }

            return View(demandePFE);
        }

        // POST: DemandePFEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.demandes == null)
            {
                return Problem("Entity set 'ENISContext.demandes'  is null.");
            }
            var demandePFE = await _context.demandes.FindAsync(id);
            if (demandePFE != null)
            {
                _context.demandes.Remove(demandePFE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemandePFEExists(int id)
        {
          return _context.demandes.Any(e => e.Id == id);
        }
    }
}
