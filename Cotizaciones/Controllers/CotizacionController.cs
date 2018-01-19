using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cotizaciones.Data;
using Cotizaciones.Models;

namespace Cotizaciones.Controllers
{
    public class CotizacionController : Controller
    {
        public static double impuest = 0.19;

        private readonly CotizacionesContext _context;
        public CotizacionController(CotizacionesContext context)
        {
            _context = context;
        }

        // GET: Cotizacion
        public async Task<IActionResult> Index()
        {
            var cotizacionesContext = _context.Cotizaciones.Include(c => c.Cliente);
            return View(await cotizacionesContext.ToListAsync());
        }

        // GET: Cotizacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizaciones
                .Include(c => c.Cliente)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // GET: Cotizacion/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre");
            return View();
        }

        // POST: Cotizacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,NReferencia,TotalNeto,Impuesto,TotalCotizacion,FechaEmision,FechaVencimiento")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cotizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", cotizacion.ClienteId);
            return View(cotizacion);
        }

         [HttpPost]
        public JsonResult SaveOrder(Cotizacion c)
        {
            double imp = c.TotalNeto*0.19;
            double total =c.TotalNeto+imp;
            
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", c.ClienteId);
            //Crear cotización
            Cotizacion newcotizacion = new Cotizacion { ClienteId= c.ClienteId, NReferencia = c.NReferencia, TotalNeto = c.TotalNeto, Impuesto = imp, TotalCotizacion = total, FechaEmision = c.FechaEmision, FechaVencimiento = DateTime.Parse("09-01-2001") };
            _context.Add(c);
            _context.SaveChangesAsync();

            //Se ingresan los servicios a la base de datos y se almacena(n) el/los id(s) en list_id_services
            var servicios = c.Servicios;
            foreach (var s in servicios)
            {
                Servicio newserv = new Servicio { Descripcion = s.Descripcion, Cantidad = s.Cantidad, ValorUnitario = s.ValorUnitario, TotalValor = s.Cantidad * s.ValorUnitario };
                _context.Servicios.Add(newserv);
                _context.SaveChangesAsync();
                //id_servicio = _context.Servicios.Last().Id;
            }

            return Json(true);
        }

        // GET: Cotizacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizaciones.SingleOrDefaultAsync(m => m.Id == id);
            if (cotizacion == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", cotizacion.ClienteId);
            return View(cotizacion);
        }

        // POST: Cotizacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,NReferencia,TotalNeto,Impuesto,TotalCotizacion,FechaEmision,FechaVencimiento")] Cotizacion cotizacion)
        {
            if (id != cotizacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionExists(cotizacion.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", cotizacion.ClienteId);
            return View(cotizacion);
        }

        // GET: Cotizacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizaciones
                .Include(c => c.Cliente)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // POST: Cotizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cotizacion = await _context.Cotizaciones.SingleOrDefaultAsync(m => m.Id == id);
            _context.Cotizaciones.Remove(cotizacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotizacionExists(int id)
        {
            return _context.Cotizaciones.Any(e => e.Id == id);
        }
    }
}
