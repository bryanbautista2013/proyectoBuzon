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
    public class PoliticasController : Controller
    {
        private readonly proyectoBuzonContext _context;

        public PoliticasController(proyectoBuzonContext context)
        {
            _context = context;
        }

        // GET: Politicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Politicas.ToListAsync());
        }

        // GET: Politicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var politicas = await _context.Politicas
                .FirstOrDefaultAsync(m => m.IdPolitica == id);
            if (politicas == null)
            {
                return NotFound();
            }

            return View(politicas);
        }

        // GET: Politicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Politicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPolitica,NomPolitica")] Politicas politicas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(politicas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(politicas);
        }

        // GET: Politicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var politicas = await _context.Politicas.FindAsync(id);
            if (politicas == null)
            {
                return NotFound();
            }
            return View(politicas);
        }

        // POST: Politicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPolitica,NomPolitica")] Politicas politicas)
        {
            if (id != politicas.IdPolitica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(politicas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliticasExists(politicas.IdPolitica))
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
            return View(politicas);
        }

        // GET: Politicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var politicas = await _context.Politicas
                .FirstOrDefaultAsync(m => m.IdPolitica == id);
            if (politicas == null)
            {
                return NotFound();
            }

            return View(politicas);
        }

        // POST: Politicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var politicas = await _context.Politicas.FindAsync(id);
            _context.Politicas.Remove(politicas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliticasExists(int id)
        {
            return _context.Politicas.Any(e => e.IdPolitica == id);
        }
    }
}
