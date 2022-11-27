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
    public class SectionsController : Controller
    {
        private readonly ENISContext _context;

        public SectionsController(ENISContext context)
        {
            _context = context;
        }

        // GET: Sections
        public async Task<IActionResult> Index()
        {
            return View(await _context.sections.ToListAsync());
        }

        // GET: Sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sections == null)
            {
                return NotFound();
            }

            var section = await _context.sections
                .FirstOrDefaultAsync(m => m.SectionId == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // GET: Sections/Create
        public async Task<IActionResult> Create()
        {

            var SectionViewModel = new SectionViewModel(new Section(), await _context.departements.ToListAsync());
            //var tuple = new Tuple<Section, IEnumerable<Departement>>(new Section(), await _context.departements.ToListAsync());
            return View(SectionViewModel);
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SectionViewModel SectionViewModel)
        {
            SectionViewModel sectionViewModel = new SectionViewModel(SectionViewModel.section!, SectionViewModel.departements!);
            if (ModelState.IsValid)
            {
                if ( _context.departements == null)
                {
                    return NotFound();
                }
                var departement = await _context.departements
                .FirstOrDefaultAsync(m => m.DepartementId == sectionViewModel.section!.DepartementId);
                if (departement == null)
                {
                    return NotFound();
                }
                Section sec = new Section()
                {
                    SectionId = sectionViewModel.section!.SectionId,
                    sectionName= sectionViewModel.section.sectionName,
                    Grade = sectionViewModel.section.Grade,
                    schoolYear= sectionViewModel.section.schoolYear,
                    Departement=departement,
                };
                _context.Add(sec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sectionViewModel);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sections == null)
            {
                return NotFound();
            }

            var section = await _context.sections.FindAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SectionId,sectionName,Grade,schoolYear")] Section section)
        {
            if (id != section.SectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(section);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionExists(section.SectionId))
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
            return View(section);
        }

        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sections == null)
            {
                return NotFound();
            }

            var section = await _context.sections
                .FirstOrDefaultAsync(m => m.SectionId == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sections == null)
            {
                return Problem("Entity set 'ENISContext.sections'  is null.");
            }
            var section = await _context.sections.FindAsync(id);
            if (section != null)
            {
                _context.sections.Remove(section);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectionExists(int id)
        {
          return _context.sections.Any(e => e.SectionId == id);
        }
    }
}
