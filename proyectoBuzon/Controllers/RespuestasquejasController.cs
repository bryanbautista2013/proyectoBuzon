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
    public class RespuestasquejasController : Controller
    {
        private readonly proyectoBuzonContext _context;

        public RespuestasquejasController(proyectoBuzonContext context)
        {
            _context = context;
        }

        // GET: Respuestasquejas
        public async Task<IActionResult> Index(int id)
        {
           // var proyectoBuzonContext = _context.Respuestasqueja.Include(r => r.IdQNavigation);
            var proyectoBuzonContext = _context.Respuestasqueja
                .Where(r=> r.IdQ==id)
                .Include(r => r.IdQNavigation);
            return View(await proyectoBuzonContext.ToListAsync());
        }

        // GET: Respuestasquejas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuestasqueja = await _context.Respuestasqueja
                .Include(r => r.IdQNavigation)
                .FirstOrDefaultAsync(m => m.IdRespuestaq == id);
            if (respuestasqueja == null)
            {
                return NotFound();
            }

            return View(respuestasqueja);
        }

        // GET: Respuestasquejas/Create
        public IActionResult Create(int? id)
        {
            //ViewData["IdQ"] = new SelectList(_context.Quejas, "IdQ", "DescripcionQ");
            ViewData["IdQ"] = id;
            return View();
        }

        // POST: Respuestasquejas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRespuestaq,IdQ,DescResp")] Respuestasqueja respuestasqueja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respuestasqueja);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            //ViewData["IdQ"] = new SelectList(_context.Quejas, "IdQ", "DescripcionQ", respuestasqueja.IdQ);
            //return View(respuestasqueja);
            return RedirectToActionPreserveMethod("listarEstado/2", "Resolver");
        }

        // GET: Respuestasquejas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuestasqueja = await _context.Respuestasqueja.FindAsync(id);
            if (respuestasqueja == null)
            {
                return NotFound();
            }
            ViewData["IdQ"] = new SelectList(_context.Quejas, "IdQ", "DescripcionQ", respuestasqueja.IdQ);
            return View(respuestasqueja);
        }

        // POST: Respuestasquejas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRespuestaq,IdQ,DescResp")] Respuestasqueja respuestasqueja)
        {
            if (id != respuestasqueja.IdRespuestaq)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respuestasqueja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespuestasquejaExists(respuestasqueja.IdRespuestaq))
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
            ViewData["IdQ"] = new SelectList(_context.Quejas, "IdQ", "DescripcionQ", respuestasqueja.IdQ);
            return View(respuestasqueja);
        }

        // GET: Respuestasquejas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuestasqueja = await _context.Respuestasqueja
                .Include(r => r.IdQNavigation)
                .FirstOrDefaultAsync(m => m.IdRespuestaq == id);
            if (respuestasqueja == null)
            {
                return NotFound();
            }

            return View(respuestasqueja);
        }

        // POST: Respuestasquejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respuestasqueja = await _context.Respuestasqueja.FindAsync(id);
            _context.Respuestasqueja.Remove(respuestasqueja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespuestasquejaExists(int id)
        {
            return _context.Respuestasqueja.Any(e => e.IdRespuestaq == id);
        }
    }
}
