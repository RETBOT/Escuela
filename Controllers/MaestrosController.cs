using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escuela.Models;

namespace Escuela.Controllers
{
    public class MaestrosController : Controller
    {
        private readonly EscuelaContext _context;

        public MaestrosController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Maestros
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.Maestros.Include(m => m.NombreMateriaNavigation);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: Maestros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Maestros == null)
            {
                return NotFound();
            }

            var maestro = await _context.Maestros
                .Include(m => m.NombreMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdMaestro == id);
            if (maestro == null)
            {
                return NotFound();
            }

            return View(maestro);
        }

        // GET: Maestros/Create
        public IActionResult Create()
        {
            ViewData["NombreMateria"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria");
            return View();
        }

        // POST: Maestros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaestro,Nombre,Apellidos,NumTelefono,Correo,NombreMateria")] Maestro maestro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maestro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NombreMateria"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", maestro.NombreMateria);
            return View(maestro);
        }

        // GET: Maestros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Maestros == null)
            {
                return NotFound();
            }

            var maestro = await _context.Maestros.FindAsync(id);
            if (maestro == null)
            {
                return NotFound();
            }
            ViewData["NombreMateria"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", maestro.NombreMateria);
            return View(maestro);
        }

        // POST: Maestros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaestro,Nombre,Apellidos,NumTelefono,Correo,NombreMateria")] Maestro maestro)
        {
            if (id != maestro.IdMaestro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maestro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaestroExists(maestro.IdMaestro))
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
            ViewData["NombreMateria"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", maestro.NombreMateria);
            return View(maestro);
        }

        // GET: Maestros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Maestros == null)
            {
                return NotFound();
            }

            var maestro = await _context.Maestros
                .Include(m => m.NombreMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdMaestro == id);
            if (maestro == null)
            {
                return NotFound();
            }

            return View(maestro);
        }

        // POST: Maestros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Maestros == null)
            {
                return Problem("Entity set 'EscuelaContext.Maestros'  is null.");
            }
            var maestro = await _context.Maestros.FindAsync(id);
            if (maestro != null)
            {
                _context.Maestros.Remove(maestro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaestroExists(int id)
        {
          return _context.Maestros.Any(e => e.IdMaestro == id);
        }
    }
}
