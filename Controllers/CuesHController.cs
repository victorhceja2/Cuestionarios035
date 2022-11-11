using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class CuesHController : Controller
    {
        private readonly MvcMovieContext _context;

        public CuesHController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: CuesH
        public async Task<IActionResult> Index()
        {
              return _context.CuesH != null ? 
                          View(await _context.CuesH.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.CuesH'  is null.");
        }

        // GET: CuesH/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CuesH == null)
            {
                return NotFound();
            }

            var cuesH = await _context.CuesH
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuesH == null)
            {
                return NotFound();
            }

            return View(cuesH);
        }

        // GET: CuesH/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CuesH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Usuario,FechaAlta,Descripcion,Estatus")] CuesH cuesH)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuesH);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuesH);
        }

        // GET: CuesH/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CuesH == null)
            {
                return NotFound();
            }

            var cuesH = await _context.CuesH.FindAsync(id);
            if (cuesH == null)
            {
                return NotFound();
            }
            return View(cuesH);
        }

        // POST: CuesH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Usuario,FechaAlta,Descripcion,Estatus")] CuesH cuesH)
        {
            if (id != cuesH.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuesH);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuesHExists(cuesH.Id))
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
            return View(cuesH);
        }

        // GET: CuesH/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CuesH == null)
            {
                return NotFound();
            }

            var cuesH = await _context.CuesH
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuesH == null)
            {
                return NotFound();
            }

            return View(cuesH);
        }

        // POST: CuesH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CuesH == null)
            {
                return Problem("Entity set 'MvcMovieContext.CuesH'  is null.");
            }
            var cuesH = await _context.CuesH.FindAsync(id);
            if (cuesH != null)
            {
                _context.CuesH.Remove(cuesH);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuesHExists(int id)
        {
          return (_context.CuesH?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
