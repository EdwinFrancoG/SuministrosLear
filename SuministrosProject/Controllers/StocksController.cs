using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuministrosProject.Models;
using Microsoft.EntityFrameworkCore;
using SuministrosProject.AppServices;

namespace SuministrosProject.Controllers
{
    public class StocksController : Controller
    {
        private SuministrosContext db = new SuministrosContext();
        public readonly stockAppServices _StockAppServices = new stockAppServices();

        // GET: Stocks
        public async Task<ActionResult> Index()
        {
            var stocks = db.Stock.Include(s => s.IdNumeroParteNavigation);
            return View(await stocks.ToListAsync());
        }

        // GET: Stocks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = await db.Stock.FindAsync(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: Stocks/Create
        public ActionResult Create()
        {
            ViewBag.IdNumeroParte = new SelectList(db.NumeroParte, "IdNumeroParte", "Descripcion");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<string> Create([Bind(Include = "IdStock,IdNumeroParte,StockInicial,FechaInicio,Entradas,Salidas,CantidadActual,Pendientes,Total,Estado")] Stock stock)
        {
            var respuestaStockServices = await _StockAppServices.IngresarStock(stock);
            bool ingresoIncorrecto = respuestaStockServices != null;
            if (ingresoIncorrecto)
            {
                ViewBag.IdNumeroParte = new SelectList(db.NumeroParte, "IdNumeroParte", "Descripcion", stock.IdNumeroParte);
                return respuestaStockServices.ToString();
            }
            else
            {
                return "OK";
            }      
        }

        // GET: Stocks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = await db.Stock.FindAsync(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdNumeroParte = new SelectList(db.NumeroParte, "IdNumeroParte", "Descripcion", stock.IdNumeroParte);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdStock,IdNumeroParte,StockInicial,FechaInicio,Entradas,Salidas,CantidadActual,Pendientes,Total,Estado")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Update(stock);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdNumeroParte = new SelectList(db.NumeroParte, "IdNumeroParte", "Descripcion", stock.IdNumeroParte);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = await db.Stock.FindAsync(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<string> DeleteConfirmed(int id)
        {
            var respuestaStockServices = await _StockAppServices.eliminarStock(id);
            if (respuestaStockServices != null)
            {
                return respuestaStockServices;
            }
            else
            {
                return "OK";
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
