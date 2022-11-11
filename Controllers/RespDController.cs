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
    public class RespDController : Controller
    {
        private readonly MvcMovieContext _context;

        public RespDController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: RespD
        public async Task<IActionResult> Index()
        {
              return _context.RespD != null ? 
                          View(await _context.RespD.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.RespD'  is null.");
        }

        // GET: RespD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RespD == null)
            {
                return NotFound();
            }

            var respD = await _context.RespD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (respD == null)
            {
                return NotFound();
            }

            return View(respD);
        }

        // GET: RespD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RespD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_CuesD,FechaAlta,Respuesta,Estatus")] RespD respD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(respD);
        }

        // GET: RespD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RespD == null)
            {
                return NotFound();
            }

            var respD = await _context.RespD.FindAsync(id);
            if (respD == null)
            {
                return NotFound();
            }
            return View(respD);
        }

        // POST: RespD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_CuesD,FechaAlta,Respuesta,Estatus")] RespD respD)
        {
            if (id != respD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespDExists(respD.Id))
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
            return View(respD);
        }

        // GET: RespD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RespD == null)
            {
                return NotFound();
            }

            var respD = await _context.RespD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (respD == null)
            {
                return NotFound();
            }

            return View(respD);
        }

        // POST: RespD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RespD == null)
            {
                return Problem("Entity set 'MvcMovieContext.RespD'  is null.");
            }
            var respD = await _context.RespD.FindAsync(id);
            if (respD != null)
            {
                _context.RespD.Remove(respD);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespDExists(int id)
        {
          return (_context.RespD?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
