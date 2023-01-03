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
    public class AlumnosController : Controller
    {
        private readonly EscuelaContext _context;

        public AlumnosController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Alumnos
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.Alumnos.Include(a => a.NombreMateria1Navigation).Include(a => a.NombreMateria2Navigation).Include(a => a.NombreMateria3Navigation).Include(a => a.NombreMateria4Navigation).Include(a => a.NombreMateria5Navigation);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .Include(a => a.NombreMateria1Navigation)
                .Include(a => a.NombreMateria2Navigation)
                .Include(a => a.NombreMateria3Navigation)
                .Include(a => a.NombreMateria4Navigation)
                .Include(a => a.NombreMateria5Navigation)
                .FirstOrDefaultAsync(m => m.IdAlumno == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // GET: Alumnos/Create
        public IActionResult Create()
        {
            ViewData["NombreMateria1"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria");
            ViewData["NombreMateria2"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria");
            ViewData["NombreMateria3"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria");
            ViewData["NombreMateria4"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria");
            ViewData["NombreMateria5"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria");
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlumno,NumControl,Nombre,Apellidos,PromedioGrals,NombreMateria1,NombreMateria2,NombreMateria3,NombreMateria4,NombreMateria5")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NombreMateria1"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria1);
            ViewData["NombreMateria2"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria2);
            ViewData["NombreMateria3"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria3);
            ViewData["NombreMateria4"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria4);
            ViewData["NombreMateria5"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria5);
            return View(alumno);
        }

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            ViewData["NombreMateria1"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria1);
            ViewData["NombreMateria2"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria2);
            ViewData["NombreMateria3"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria3);
            ViewData["NombreMateria4"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria4);
            ViewData["NombreMateria5"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria5);
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlumno,NumControl,Nombre,Apellidos,PromedioGrals,NombreMateria1,NombreMateria2,NombreMateria3,NombreMateria4,NombreMateria5")] Alumno alumno)
        {
            if (id != alumno.IdAlumno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.IdAlumno))
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
            ViewData["NombreMateria1"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria1);
            ViewData["NombreMateria2"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria2);
            ViewData["NombreMateria3"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria3);
            ViewData["NombreMateria4"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria4);
            ViewData["NombreMateria5"] = new SelectList(_context.Materias, "NombreMateria", "NombreMateria", alumno.NombreMateria5);
            return View(alumno);
        }

        // GET: Alumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .Include(a => a.NombreMateria1Navigation)
                .Include(a => a.NombreMateria2Navigation)
                .Include(a => a.NombreMateria3Navigation)
                .Include(a => a.NombreMateria4Navigation)
                .Include(a => a.NombreMateria5Navigation)
                .FirstOrDefaultAsync(m => m.IdAlumno == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alumnos == null)
            {
                return Problem("Entity set 'EscuelaContext.Alumnos'  is null.");
            }
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(int id)
        {
          return _context.Alumnos.Any(e => e.IdAlumno == id);
        }
    }
}
