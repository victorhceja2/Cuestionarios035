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
    public class Proceso2Controller : Controller
    {
        private readonly MvcMovieContext _context;

        public Proceso2Controller(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Proceso2
        public async Task<IActionResult> Index()
        {
            var loginsesion= HttpContext.Session.GetObject<Login>("ObjetoComplejo");
            if(loginsesion == null)
             {
                return RedirectToAction("Create","Login");
             }         
             if(loginsesion.Nivel == 5)
             {return RedirectToAction("Create","Login");}
             if(loginsesion.Nivel <= 1){            
              return _context.Proceso != null ? 
                          View(await _context.Proceso.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.Proceso'  is null.");
             }
            else{
                    return RedirectToAction("Index","Home");}                               
        }

        // GET: Proceso2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proceso == null)
            {
                return NotFound();
            }

            var proceso = await _context.Proceso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proceso == null)
            {
                return NotFound();
            }

            return View(proceso);
        }

        // GET: Proceso2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proceso2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Campana,FechaAlta,Url,Comentarios,Estatus")] Proceso proceso)
        {
            if (ModelState.IsValid)
            {
                                //Aqui va el proceso para hacer las preguntas de forma dinamica



                
                var sQuery = from m in _context.Campana
                                            join mu in _context.Usuario on m.Id_Usuario equals mu.Id
                                            join mh in _context.CuesH on m.Id_CuesH equals mh.Id
                                            join md in _context.CuesD on mh.Id equals md.Id_CuesH

                                    select new
                                    {
                                        m.Id,
                                        mu.Nombre,
                                        mu.Apellido,
                                        mu.CorreoElectronico,
                                        m.Comentarios,
                                        md.Preguntaa,
                                        mu.NumeroEmpleados
                                    };


                int nEmpleado = 0;

                foreach (var r in sQuery)
                {
                    nEmpleado = int.Parse(r.NumeroEmpleados.ToString());
                }

                for (int x = 1 ; x <= nEmpleado; x++)
                {

                    List<Formulario> lfr = new List<Formulario>();
                    Formulario fr = new Formulario();
                    


                    foreach (var reg in sQuery )
                    {
                        fr =new Formulario();
                        fr.Id_Campana = proceso.Id_Campana;
                        fr.Nombre = "<<escriba aqui su nombre y apellido>>";
                        fr.FechaAlta = DateTime.Now;
                        fr.CorreoElectronico = reg.CorreoElectronico;
                        fr.Descripcion = reg.Comentarios;
                        fr.Pregunta = reg.Preguntaa;
                        fr.Respuesta = "<<escriba aqui su respuesta>>";
                        fr.Comentarios ="<<escriba aqui sus comentarios>>";
                        fr.Empleado = x;
                        lfr.Add(fr);

                    } 

                    _context.Formulario.AddRange(lfr);

                }
 
                proceso.Url ="https://";
                _context.Add(proceso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proceso);
        }

        // GET: Proceso2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proceso == null)
            {
                return NotFound();
            }

            var proceso = await _context.Proceso.FindAsync(id);
            if (proceso == null)
            {
                return NotFound();
            }
            return View(proceso);
        }

        // POST: Proceso2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Campana,FechaAlta,Url,Comentarios,Estatus")] Proceso proceso)
        {
            if (id != proceso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proceso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesoExists(proceso.Id))
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
            return View(proceso);
        }

        // GET: Proceso2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proceso == null)
            {
                return NotFound();
            }

            var proceso = await _context.Proceso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proceso == null)
            {
                return NotFound();
            }

            return View(proceso);
        }

        // POST: Proceso2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proceso == null)
            {
                return Problem("Entity set 'MvcMovieContext.Proceso'  is null.");
            }
            var proceso = await _context.Proceso.FindAsync(id);
            if (proceso != null)
            {
                _context.Proceso.Remove(proceso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesoExists(int id)
        {
          return (_context.Proceso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
