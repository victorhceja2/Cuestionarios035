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
    public class FoliadorController : Controller
    {
        private readonly MvcMovieContext _context;

        public FoliadorController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Foliador
        public async Task<IActionResult> Index()
        {
              return _context.Foliador != null ? 
                          View(await _context.Foliador.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.Foliador'  is null.");
        }

        // GET: Foliador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Foliador == null)
            {
                return NotFound();
            }

            var foliador = await _context.Foliador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foliador == null)
            {
                return NotFound();
            }

            return View(foliador);
        }

        // GET: Foliador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foliador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Origen")] Foliador foliador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foliador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foliador);
        }

        // GET: Foliador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Foliador == null)
            {
                return NotFound();
            }

            var foliador = await _context.Foliador.FindAsync(id);
            if (foliador == null)
            {
                return NotFound();
            }
            return View(foliador);
        }

        // POST: Foliador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Origen")] Foliador foliador)
        {
            if (id != foliador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foliador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoliadorExists(foliador.Id))
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
            return View(foliador);
        }

        // GET: Foliador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Foliador == null)
            {
                return NotFound();
            }

            var foliador = await _context.Foliador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foliador == null)
            {
                return NotFound();
            }

            return View(foliador);
        }

        // POST: Foliador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Foliador == null)
            {
                return Problem("Entity set 'MvcMovieContext.Foliador'  is null.");
            }
            var foliador = await _context.Foliador.FindAsync(id);
            if (foliador != null)
            {
                _context.Foliador.Remove(foliador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoliadorExists(int id)
        {
          return (_context.Foliador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
