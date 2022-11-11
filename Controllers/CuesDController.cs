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
    public class CuesDController : Controller
    {
        private readonly MvcMovieContext _context;

        public CuesDController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: CuesD
        public async Task<IActionResult> Index()
        {
              return _context.CuesD != null ? 
                          View(await _context.CuesD.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.CuesD'  is null.");
        }

        // GET: CuesD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CuesD == null)
            {
                return NotFound();
            }

            var cuesD = await _context.CuesD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuesD == null)
            {
                return NotFound();
            }

            return View(cuesD);
        }

        // GET: CuesD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CuesD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_CuesH,FechaAlta,Preguntaa,Respuesta,Estatus")] CuesD cuesD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuesD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuesD);
        }

        // GET: CuesD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CuesD == null)
            {
                return NotFound();
            }

            var cuesD = await _context.CuesD.FindAsync(id);
            if (cuesD == null)
            {
                return NotFound();
            }
            return View(cuesD);
        }

        // POST: CuesD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_CuesH,FechaAlta,Preguntaa,Respuesta,Estatus")] CuesD cuesD)
        {
            if (id != cuesD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuesD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuesDExists(cuesD.Id))
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
            return View(cuesD);
        }

        // GET: CuesD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CuesD == null)
            {
                return NotFound();
            }

            var cuesD = await _context.CuesD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuesD == null)
            {
                return NotFound();
            }

            return View(cuesD);
        }

        // POST: CuesD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CuesD == null)
            {
                return Problem("Entity set 'MvcMovieContext.CuesD'  is null.");
            }
            var cuesD = await _context.CuesD.FindAsync(id);
            if (cuesD != null)
            {
                _context.CuesD.Remove(cuesD);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuesDExists(int id)
        {
          return (_context.CuesD?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
