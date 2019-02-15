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
    public class QuejasController : Controller
    {
        private readonly proyectoBuzonContext _context;

        public QuejasController(proyectoBuzonContext context)
        {
            _context = context;
        }

        // GET: Quejas
        public async Task<IActionResult> Index()
        {
            var proyectoBuzonContext = _context.Quejas.Include(q => q.IdClNavigation).Include(q => q.IdEstadoNavigation).Include(q => q.IdPedidoNavigation).Include(q => q.IdPoliticaNavigation).Include(q => q.IdTipoqNavigation);
            return View(await proyectoBuzonContext.ToListAsync());
        }


        public async Task<IActionResult> IndexRespuesta(int id)
        {
            // var proyectoBuzonContext = _context.Respuestasqueja.Include(r => r.IdQNavigation);
            var proyectoBuzonContext = _context.Respuestasqueja
                .Where(r => r.IdQ == id)
                .Include(r => r.IdQNavigation);
            return View(await proyectoBuzonContext.ToListAsync());
        }
        public async Task<IActionResult> IndexPendientes(int id = 1, int c=1)
        {
            var proyectoBuzonContext = _context.Quejas
                .Where(q => q.IdEstado == id)
                .Where(q => q.IdCl == c)
                .Include(q => q.IdClNavigation).Include(q => q.IdEstadoNavigation).Include(q => q.IdPedidoNavigation).Include(q => q.IdPoliticaNavigation).Include(q => q.IdTipoqNavigation);

            return View(await proyectoBuzonContext.ToListAsync());
        }


        public async Task<IActionResult> IndexSolucionadas(int id = 2, int c = 1)
        {
            var proyectoBuzonContext = _context.Quejas
                .Where(q => q.IdEstado == id)
                    .Where(q => q.IdCl == c)
                .Include(q => q.IdClNavigation).Include(q => q.IdEstadoNavigation).Include(q => q.IdPedidoNavigation).Include(q => q.IdPoliticaNavigation).Include(q => q.IdTipoqNavigation);

            return View(await proyectoBuzonContext.ToListAsync());
        }

        public IActionResult Pendysol()
        {
            return View();
        }

        public async Task<IActionResult> listarEstado(int id)
        {
            var proyectoBuzonContext = _context.Quejas.Where(q => q.IdEstado == id)
                .Include(q => q.IdClNavigation).Include(q => q.IdEstadoNavigation).Include(q => q.IdPedidoNavigation).Include(q => q.IdPoliticaNavigation).Include(q => q.IdTipoqNavigation);

            // consultar datos de la Queja

            var estado = _context.Estado.Find(id);
            ViewData["estado"] = estado;


            return View(await proyectoBuzonContext.ToListAsync());
        }


        // GET: Quejas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quejas = await _context.Quejas
                .Include(q => q.IdClNavigation)
                .Include(q => q.IdEstadoNavigation)
                .Include(q => q.IdPedidoNavigation)
                .Include(q => q.IdPoliticaNavigation)
                .Include(q => q.IdTipoqNavigation)
                .FirstOrDefaultAsync(m => m.IdQ == id);
            if (quejas == null)
            {
                return NotFound();
            }

            return View(quejas);
        }

        // GET: Quejas/Create
        public IActionResult Create()
        {
            ViewData["IdCl"] = new SelectList(_context.TblCliente, "IdCl", "NombresCl");
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "NomEstado");
            ViewData["IdPedido"] = new SelectList(_context.Pedido, "IdPedido", "IdPedido");
            ViewData["IdPolitica"] = new SelectList(_context.Politicas, "IdPolitica", "NomPolitica");
            ViewData["IdTipoq"] = new SelectList(_context.Tipoqueja, "IdTipoq", "NombreTipoq");
            return View();
        }

        // POST: Quejas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdQ,IdCl,IdTipoq,IdPolitica,IdPedido,IdEstado,DescripcionQ,FechaQ")] Quejas quejas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quejas);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            ViewData["IdCl"] = new SelectList(_context.TblCliente, "IdCl", "ApellidosCl", quejas.IdCl);
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "NomEstado", quejas.IdEstado);
            ViewData["IdPedido"] = new SelectList(_context.Pedido, "IdPedido", "IdPedido", quejas.IdPedido);
            ViewData["IdPolitica"] = new SelectList(_context.Politicas, "IdPolitica", "NomPolitica", quejas.IdPolitica);
            ViewData["IdTipoq"] = new SelectList(_context.Tipoqueja, "IdTipoq", "NombreTipoq", quejas.IdTipoq);
            return RedirectToActionPreserveMethod("indexPendientes", "Quejas");
        }

        // GET: Quejas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quejas = await _context.Quejas.FindAsync(id);
            if (quejas == null)
            {
                return NotFound();
            }
            ViewData["IdCl"] = new SelectList(_context.TblCliente, "IdCl", "NombresCl", quejas.IdCl);
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "NomEstado", quejas.IdEstado);
            ViewData["IdPedido"] = new SelectList(_context.Pedido, "IdPedido", "IdPedido", quejas.IdPedido);
            ViewData["IdPolitica"] = new SelectList(_context.Politicas, "IdPolitica", "NomPolitica", quejas.IdPolitica);
            ViewData["IdTipoq"] = new SelectList(_context.Tipoqueja, "IdTipoq", "NombreTipoq", quejas.IdTipoq);
            return View(quejas);
        }

        // POST: Quejas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdQ,IdCl,IdTipoq,IdPolitica,IdPedido,IdEstado,DescripcionQ,FechaQ")] Quejas quejas)
        {
            if (id != quejas.IdQ)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quejas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuejasExists(quejas.IdQ))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
            }
            ViewData["IdCl"] = new SelectList(_context.TblCliente, "IdCl", "ApellidosCl", quejas.IdCl);
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "NomEstado", quejas.IdEstado);
            ViewData["IdPedido"] = new SelectList(_context.Pedido, "IdPedido", "IdPedido", quejas.IdPedido);
            ViewData["IdPolitica"] = new SelectList(_context.Politicas, "IdPolitica", "NomPolitica", quejas.IdPolitica);
            ViewData["IdTipoq"] = new SelectList(_context.Tipoqueja, "IdTipoq", "NombreTipoq", quejas.IdTipoq);
            return RedirectToActionPreserveMethod("indexPendientes", "Quejas");
            //return View(quejas);
        }

        // GET: Quejas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quejas = await _context.Quejas
                .Include(q => q.IdClNavigation)
                .Include(q => q.IdEstadoNavigation)
                .Include(q => q.IdPedidoNavigation)
                .Include(q => q.IdPoliticaNavigation)
                .Include(q => q.IdTipoqNavigation)
                .FirstOrDefaultAsync(m => m.IdQ == id);
            if (quejas == null)
            {
                return NotFound();
            }

            return View(quejas);
        }

        // POST: Quejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quejas = await _context.Quejas.FindAsync(id);
            _context.Quejas.Remove(quejas);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToActionPreserveMethod("indexPendientes", "Quejas");
        }

        private bool QuejasExists(int id)
        {
            return _context.Quejas.Any(e => e.IdQ == id);
        }
    }
}
