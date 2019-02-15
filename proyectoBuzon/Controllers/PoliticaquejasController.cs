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
    public class PoliticaquejasController : Controller
    {
        private readonly proyectoBuzonContext _context;

        public PoliticaquejasController(proyectoBuzonContext context)
        {
            _context = context;
        }

        // GET: Politicaquejas
        public async Task<IActionResult> Index()
        {
            var proyectoBuzonContext = _context.Politicaquejas.Include(p => p.IdPoliticaNavigation).Include(p => p.IdTipoqNavigation);
            return View(await proyectoBuzonContext.ToListAsync());
        }

        // GET: Politicaquejas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var politicaquejas = await _context.Politicaquejas
                .Include(p => p.IdPoliticaNavigation)
                .Include(p => p.IdTipoqNavigation)
                .FirstOrDefaultAsync(m => m.IdPoliticaQuejas == id);
            if (politicaquejas == null)
            {
                return NotFound();
            }

            return View(politicaquejas);
        }

        // GET: Politicaquejas/Create
        public IActionResult Create()
        {
            ViewData["IdPolitica"] = new SelectList(_context.Politicas, "IdPolitica", "NomPolitica");
            ViewData["IdTipoq"] = new SelectList(_context.Tipoqueja, "IdTipoq", "NombreTipoq");
            return View();
        }

        // POST: Politicaquejas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPoliticaQuejas,IdTipoq,IdPolitica")] Politicaquejas politicaquejas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(politicaquejas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPolitica"] = new SelectList(_context.Politicas, "IdPolitica", "NomPolitica", politicaquejas.IdPolitica);
            ViewData["IdTipoq"] = new SelectList(_context.Tipoqueja, "IdTipoq", "NombreTipoq", politicaquejas.IdTipoq);
            return View(politicaquejas);
        }

        // GET: Politicaquejas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var politicaquejas = await _context.Politicaquejas.FindAsync(id);
            if (politicaquejas == null)
            {
                return NotFound();
            }
            ViewData["IdPolitica"] = new SelectList(_context.Politicas, "IdPolitica", "NomPolitica", politicaquejas.IdPolitica);
            ViewData["IdTipoq"] = new SelectList(_context.Tipoqueja, "IdTipoq", "NombreTipoq", politicaquejas.IdTipoq);
            return View(politicaquejas);
        }

        // POST: Politicaquejas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPoliticaQuejas,IdTipoq,IdPolitica")] Politicaquejas politicaquejas)
        {
            if (id != politicaquejas.IdPoliticaQuejas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(politicaquejas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliticaquejasExists(politicaquejas.IdPoliticaQuejas))
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
            ViewData["IdPolitica"] = new SelectList(_context.Politicas, "IdPolitica", "NomPolitica", politicaquejas.IdPolitica);
            ViewData["IdTipoq"] = new SelectList(_context.Tipoqueja, "IdTipoq", "NombreTipoq", politicaquejas.IdTipoq);
            return View(politicaquejas);
        }

        // GET: Politicaquejas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var politicaquejas = await _context.Politicaquejas
                .Include(p => p.IdPoliticaNavigation)
                .Include(p => p.IdTipoqNavigation)
                .FirstOrDefaultAsync(m => m.IdPoliticaQuejas == id);
            if (politicaquejas == null)
            {
                return NotFound();
            }

            return View(politicaquejas);
        }

        // POST: Politicaquejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var politicaquejas = await _context.Politicaquejas.FindAsync(id);
            _context.Politicaquejas.Remove(politicaquejas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliticaquejasExists(int id)
        {
            return _context.Politicaquejas.Any(e => e.IdPoliticaQuejas == id);
        }
    }
}
