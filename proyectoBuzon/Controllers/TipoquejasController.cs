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
    public class TipoquejasController : Controller
    {
        private readonly proyectoBuzonContext _context;

        public TipoquejasController(proyectoBuzonContext context)
        {
            _context = context;
        }

        // GET: Tipoquejas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipoqueja.ToListAsync());
        }

        // GET: Tipoquejas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoqueja = await _context.Tipoqueja
                .FirstOrDefaultAsync(m => m.IdTipoq == id);
            if (tipoqueja == null)
            {
                return NotFound();
            }

            return View(tipoqueja);
        }

        // GET: Tipoquejas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipoquejas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoq,NombreTipoq")] Tipoqueja tipoqueja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoqueja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoqueja);
        }

        // GET: Tipoquejas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoqueja = await _context.Tipoqueja.FindAsync(id);
            if (tipoqueja == null)
            {
                return NotFound();
            }
            return View(tipoqueja);
        }

        // POST: Tipoquejas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoq,NombreTipoq")] Tipoqueja tipoqueja)
        {
            if (id != tipoqueja.IdTipoq)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoqueja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoquejaExists(tipoqueja.IdTipoq))
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
            return View(tipoqueja);
        }

        // GET: Tipoquejas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoqueja = await _context.Tipoqueja
                .FirstOrDefaultAsync(m => m.IdTipoq == id);
            if (tipoqueja == null)
            {
                return NotFound();
            }

            return View(tipoqueja);
        }

        // POST: Tipoquejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoqueja = await _context.Tipoqueja.FindAsync(id);
            _context.Tipoqueja.Remove(tipoqueja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoquejaExists(int id)
        {
            return _context.Tipoqueja.Any(e => e.IdTipoq == id);
        }
    }
}
