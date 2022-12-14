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
    public class UsuariosController : Controller
    {
        private readonly MvcMovieContext _context;

        public UsuariosController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Usuarios
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
              return _context.Usuario != null ? 
                          View(await _context.Usuario.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.Usuario'  is null.");
             }
            else{
                    return RedirectToAction("Index","Home");}                           
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,CorreoElectronico,NumeroContrato,NombreEmpresa,NumeroEmpleados,RFC,Domicilio,Colonia,Ciudad,Pais,Giro,Password,FechaAlta,Nivel")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                
               
                
                int idia = (int)DateTime.Now.Day; 
                int imes = (int)DateTime.Now.Month;
                int iano = (int)DateTime.Now.Year;
                string sano2 = iano.ToString().Substring(2,2);
                int ilen = 2;
                string sdia = idia.ToString();
                string smes = imes.ToString();
                string sano = sano2;
                sdia= sdia.PadLeft(ilen,'0').Substring(0,ilen);
                smes= smes.PadLeft(ilen,'0').Substring(0,ilen);
                sano= sano.PadLeft(ilen,'0').Substring(0,ilen);
                Foliador folio = new Foliador();
                folio.Origen="Contratos";
                _context.Foliador.Add(folio);
                _context.SaveChanges();
                int lastFolioId = _context.Foliador.Max(item => item.Id);
                string sLastFolio = lastFolioId.ToString();
                sLastFolio = sLastFolio.PadLeft(4,'0').Substring(0,4);


                
                usuario.NumeroContrato = sdia + smes + sano + 
                usuario.NumeroEmpleados + usuario.Giro.Substring(0,2) + 
                usuario.Ciudad.Substring(0,2) + sLastFolio;

                
                
                await _context.SaveChangesAsync();
                Contrato contra = new Contrato();
                int lastUserId = _context.Usuario.Max(item => item.Id);
                contra.Id_Usuario = lastUserId;
                contra.FechaAlta = DateTime.Now;
                contra.NumeroContrato = usuario.NumeroContrato;
                contra.Activo=1;
                contra.Comentarios="Generado desde la alta de usuario";
                _context.Contrato.Add(contra);
                _context.SaveChanges();
                string texto = $"Bienvenido { usuario.Nombre} a 035.MX ha sido registrado con ??xito, con este numero de contrato: {usuario.NumeroContrato}";
                EnviarMail.Send(usuario.CorreoElectronico,"Registro 035.MX", texto);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
        public IActionResult Create2()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2([Bind("Id,Nombre,Apellido,CorreoElectronico,NumeroContrato,NombreEmpresa,NumeroEmpleados,RFC,Domicilio,Colonia,Ciudad,Pais,Giro,Password,FechaAlta,Nivel")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Nivel = 2; //El registro siempre sera nivel 2, solo que entre un administrador y le otorge nivel 1 o 0
                _context.Add(usuario);
                EnviarMail.Send(usuario.CorreoElectronico,"Registro 035.MX", "Bienvenido a 035.MX ha sido registrado con ??xito");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }        

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,CorreoElectronico,NumeroContrato,NombreEmpresa,NumeroEmpleados,RFC,Domicilio,Colonia,Ciudad,Pais,Giro,Password,FechaAlta,Nivel")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'MvcMovieContext.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
