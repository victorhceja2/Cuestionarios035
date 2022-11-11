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
    public class CampanaController : Controller
    {
        private readonly MvcMovieContext _context;

        public CampanaController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Campana
        public async Task<IActionResult> Index()
        {
              return _context.Campana != null ? 
                          View(await _context.Campana.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.Campana'  is null.");
        }

        // GET: Campana/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Campana == null)
            {
                return NotFound();
            }

            var campana = await _context.Campana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campana == null)
            {
                return NotFound();
            }

            return View(campana);
        }

        // GET: Campana/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campana/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Usuario,Id_CuesH,FechaAlta,Comentarios,Dias,Estatus")] Campana campana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campana);
        }

        // GET: Campana/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Campana == null)
            {
                return NotFound();
            }

            var campana = await _context.Campana.FindAsync(id);
            if (campana == null)
            {
                return NotFound();
            }
            return View(campana);
        }

        // POST: Campana/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Usuario,Id_CuesH,FechaAlta,Comentarios,Dias,Estatus")] Campana campana)
        {
            if (id != campana.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampanaExists(campana.Id))
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
            return View(campana);
        }

        // GET: Campana/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Campana == null)
            {
                return NotFound();
            }

            var campana = await _context.Campana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campana == null)
            {
                return NotFound();
            }

            return View(campana);
        }

        // POST: Campana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Campana == null)
            {
                return Problem("Entity set 'MvcMovieContext.Campana'  is null.");
            }
            var campana = await _context.Campana.FindAsync(id);
            if (campana != null)
            {
                _context.Campana.Remove(campana);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampanaExists(int id)
        {
          return (_context.Campana?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
