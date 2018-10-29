using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ponderer.Data;
using Ponderer.Models;

namespace Ponderer.Controllers
{
    public class MantrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MantrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mantras
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Mantras.Include(m => m.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Mantras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantra = await _context.Mantras
                .Include(m => m.ApplicationUser)
                .FirstOrDefaultAsync(m => m.MantraId == id);
            if (mantra == null)
            {
                return NotFound();
            }

            return View(mantra);
        }

        // GET: Mantras/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: Mantras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MantraId,MorningMantra,PlaceFound,ApplicationUserId")] Mantra mantra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mantra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", mantra.ApplicationUserId);
            return View(mantra);
        }

        // GET: Mantras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantra = await _context.Mantras.FindAsync(id);
            if (mantra == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", mantra.ApplicationUserId);
            return View(mantra);
        }

        // POST: Mantras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MantraId,MorningMantra,PlaceFound,ApplicationUserId")] Mantra mantra)
        {
            if (id != mantra.MantraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mantra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MantraExists(mantra.MantraId))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", mantra.ApplicationUserId);
            return View(mantra);
        }

        // GET: Mantras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantra = await _context.Mantras
                .Include(m => m.ApplicationUser)
                .FirstOrDefaultAsync(m => m.MantraId == id);
            if (mantra == null)
            {
                return NotFound();
            }

            return View(mantra);
        }

        // POST: Mantras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mantra = await _context.Mantras.FindAsync(id);
            _context.Mantras.Remove(mantra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MantraExists(int id)
        {
            return _context.Mantras.Any(e => e.MantraId == id);
        }
    }
}
