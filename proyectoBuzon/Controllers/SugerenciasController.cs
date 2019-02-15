using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectoBuzon.Models;

namespace proyectoBuzon.Controllers
{
    public class SugerenciasController : Controller
    {
        private readonly proyectoBuzonContext _context;

        public SugerenciasController(proyectoBuzonContext context)
        {
            _context = context;
        }

        // GET: Sugerencias
        public async Task<IActionResult> Index(int c = 1)
        {
            var proyectoBuzonContext = _context.Sugerencias
                .Where(s => s.IdCl == c)
                .Include(s => s.IdClNavigation).Include(s => s.IdTiposugNavigation);
            return View(await proyectoBuzonContext.ToListAsync());
        }
        public async Task<IActionResult> IndexAdmin()
        {
            var proyectoBuzonContext = _context.Sugerencias.Include(s => s.IdClNavigation).Include(s => s.IdTiposugNavigation);
            return View(await proyectoBuzonContext.ToListAsync());
        }

        // GET: Sugerencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sugerencias = await _context.Sugerencias
                .Include(s => s.IdClNavigation)
                .Include(s => s.IdTiposugNavigation)
                .FirstOrDefaultAsync(m => m.IdS == id);
            if (sugerencias == null)
            {
                return NotFound();
            }

            return View(sugerencias);
        }

        // GET: Sugerencias/Create
        public IActionResult Create()
        {
            ViewData["IdCl"] = new SelectList(_context.TblCliente, "IdCl", "ApellidosCl");
            ViewData["IdTiposug"] = new SelectList(_context.Tiposugerencia, "IdTiposug", "NombreTipoq");
            return View();
        }

        // POST: Sugerencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdS,IdCl,DescripcionS,FechaS,IdTiposug")] Sugerencias sugerencias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sugerencias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCl"] = new SelectList(_context.TblCliente, "IdCl", "ApellidosCl", sugerencias.IdCl);
            ViewData["IdTiposug"] = new SelectList(_context.Tiposugerencia, "IdTiposug", "NombreTipoq", sugerencias.IdTiposug);
            return View(sugerencias);
        }

        // GET: Sugerencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sugerencias = await _context.Sugerencias.FindAsync(id);
            if (sugerencias == null)
            {
                return NotFound();
            }
            ViewData["IdCl"] = new SelectList(_context.TblCliente, "IdCl", "ApellidosCl", sugerencias.IdCl);
            ViewData["IdTiposug"] = new SelectList(_context.Tiposugerencia, "IdTiposug", "NombreTipoq", sugerencias.IdTiposug);
            return View(sugerencias);
        }

        // POST: Sugerencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdS,IdCl,DescripcionS,FechaS,IdTiposug")] Sugerencias sugerencias)
        {
            if (id != sugerencias.IdS)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sugerencias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SugerenciasExists(sugerencias.IdS))
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
            ViewData["IdCl"] = new SelectList(_context.TblCliente, "IdCl", "ApellidosCl", sugerencias.IdCl);
            ViewData["IdTiposug"] = new SelectList(_context.Tiposugerencia, "IdTiposug", "NombreTipoq", sugerencias.IdTiposug);
            return View(sugerencias);
        }

        // GET: Sugerencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sugerencias = await _context.Sugerencias
                .Include(s => s.IdClNavigation)
                .Include(s => s.IdTiposugNavigation)
                .FirstOrDefaultAsync(m => m.IdS == id);
            if (sugerencias == null)
            {
                return NotFound();
            }

            return View(sugerencias);
        }

        // POST: Sugerencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sugerencias = await _context.Sugerencias.FindAsync(id);
            _context.Sugerencias.Remove(sugerencias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SugerenciasExists(int id)
        {
            return _context.Sugerencias.Any(e => e.IdS == id);
        }
    }
}
