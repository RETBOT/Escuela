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
    public class CalificacionesController : Controller
    {
        private readonly EscuelaContext _context;

        public CalificacionesController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Calificaciones
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.Calificaciones.Include(c => c.NombreMateriaNavigation).Include(c => c.NumControlNavigation);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: Calificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calificaciones == null)
            {
                return NotFound();
            }

            var calificacione = await _context.Calificaciones
                .Include(c => c.NombreMateriaNavigation)
                .Include(c => c.NumControlNavigation)
                .FirstOrDefaultAsync(m => m.IdCalificacion == id);
            if (calificacione == null)
            {
                return NotFound();
            }

            return View(calificacione);
        }

        // GET: Calificaciones/Create
        public IActionResult Create()
        {
            ViewData["NombreMateria"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria");
            ViewData["NumControl"] = new SelectList(_context.Alumnos, "NumControl", "NumControl");
            return View();
        }

        // POST: Calificaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCalificacion,Unidad1,Unidad2,Unidad3,CaliFinal,NombreMateria,NumControl")] Calificacione calificacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NombreMateria"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", calificacione.NombreMateria);
            ViewData["NumControl"] = new SelectList(_context.Alumnos, "NumControl", "NumControl", calificacione.NumControl);
            return View(calificacione);
        }

        // GET: Calificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Calificaciones == null)
            {
                return NotFound();
            }

            var calificacione = await _context.Calificaciones.FindAsync(id);
            if (calificacione == null)
            {
                return NotFound();
            }
            ViewData["NombreMateria"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", calificacione.NombreMateria);
            ViewData["NumControl"] = new SelectList(_context.Alumnos, "NumControl", "NumControl", calificacione.NumControl);
            return View(calificacione);
        }

        // POST: Calificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCalificacion,Unidad1,Unidad2,Unidad3,CaliFinal,NombreMateria,NumControl")] Calificacione calificacione)
        {
            if (id != calificacione.IdCalificacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacioneExists(calificacione.IdCalificacion))
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
            ViewData["NombreMateria"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", calificacione.NombreMateria);
            ViewData["NumControl"] = new SelectList(_context.Alumnos, "NumControl", "NumControl", calificacione.NumControl);
            return View(calificacione);
        }

        // GET: Calificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calificaciones == null)
            {
                return NotFound();
            }

            var calificacione = await _context.Calificaciones
                .Include(c => c.NombreMateriaNavigation)
                .Include(c => c.NumControlNavigation)
                .FirstOrDefaultAsync(m => m.IdCalificacion == id);
            if (calificacione == null)
            {
                return NotFound();
            }

            return View(calificacione);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calificaciones == null)
            {
                return Problem("Entity set 'EscuelaContext.Calificaciones'  is null.");
            }
            var calificacione = await _context.Calificaciones.FindAsync(id);
            if (calificacione != null)
            {
                _context.Calificaciones.Remove(calificacione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacioneExists(int id)
        {
          return _context.Calificaciones.Any(e => e.IdCalificacion == id);
        }
    }
}
