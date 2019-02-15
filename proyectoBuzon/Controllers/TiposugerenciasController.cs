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
    public class TiposugerenciasController : Controller
    {
        private readonly proyectoBuzonContext _context;

        public TiposugerenciasController(proyectoBuzonContext context)
        {
            _context = context;
        }

        // GET: Tiposugerencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiposugerencia.ToListAsync());
        }

        // GET: Tiposugerencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposugerencia = await _context.Tiposugerencia
                .FirstOrDefaultAsync(m => m.IdTiposug == id);
            if (tiposugerencia == null)
            {
                return NotFound();
            }

            return View(tiposugerencia);
        }

        // GET: Tiposugerencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiposugerencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTiposug,NombreTipoq")] Tiposugerencia tiposugerencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposugerencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposugerencia);
        }

        // GET: Tiposugerencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposugerencia = await _context.Tiposugerencia.FindAsync(id);
            if (tiposugerencia == null)
            {
                return NotFound();
            }
            return View(tiposugerencia);
        }

        // POST: Tiposugerencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTiposug,NombreTipoq")] Tiposugerencia tiposugerencia)
        {
            if (id != tiposugerencia.IdTiposug)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposugerencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposugerenciaExists(tiposugerencia.IdTiposug))
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
            return View(tiposugerencia);
        }

        // GET: Tiposugerencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposugerencia = await _context.Tiposugerencia
                .FirstOrDefaultAsync(m => m.IdTiposug == id);
            if (tiposugerencia == null)
            {
                return NotFound();
            }

            return View(tiposugerencia);
        }

        // POST: Tiposugerencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposugerencia = await _context.Tiposugerencia.FindAsync(id);
            _context.Tiposugerencia.Remove(tiposugerencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposugerenciaExists(int id)
        {
            return _context.Tiposugerencia.Any(e => e.IdTiposug == id);
        }
    }
}
