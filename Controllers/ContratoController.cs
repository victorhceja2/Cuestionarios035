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
    public class ContratoController : Controller
    {
        private readonly MvcMovieContext _context;

        public ContratoController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Contrato
        public async Task<IActionResult> Index()
        {
              return _context.Contrato != null ? 
                          View(await _context.Contrato.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.Contrato'  is null.");
        }

        // GET: Contrato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contrato == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // GET: Contrato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contrato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Usuario,NumeroContrato,FechaAlta,Comentarios,Activo")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contrato);
        }

        // GET: Contrato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contrato == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            return View(contrato);
        }

        // POST: Contrato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Usuario,NumeroContrato,FechaAlta,Comentarios,Activo")] Contrato contrato)
        {
            if (id != contrato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExists(contrato.Id))
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
            return View(contrato);
        }

        // GET: Contrato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contrato == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // POST: Contrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contrato == null)
            {
                return Problem("Entity set 'MvcMovieContext.Contrato'  is null.");
            }
            var contrato = await _context.Contrato.FindAsync(id);
            if (contrato != null)
            {
                _context.Contrato.Remove(contrato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoExists(int id)
        {
          return (_context.Contrato?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
