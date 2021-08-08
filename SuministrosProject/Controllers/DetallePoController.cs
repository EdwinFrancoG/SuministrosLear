using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuministrosProject.Models;
using System.Linq;

namespace SuministrosProject.Controllers
{
    public class DetallePoController : Controller
    {
        private SuministrosContext db = new SuministrosContext();

        // GET: DetallePo
        public async Task<ActionResult> Index(int? idProdOrder)
        {
            idProdOrder = 7;
            var PO = db.ProductOrder.Where(p => p.IdProductOrder == idProdOrder).FirstOrDefault();
            ViewData["PO"] = PO.Codigo;
            ViewData["fecha"] = PO.Fecha;
            ViewData["req"] = PO.Requisicion;
            var verDetallePO = db.DetallePo.Where(d => d.IdProductOrder == idProdOrder).Include(d => d.IdSuministroNavigation);
            return View(await verDetallePO.ToListAsync());
        }

        // GET: DetallePo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePo detallePo = await db.DetallePo.FindAsync(id);
            if (detallePo == null)
            {
                return HttpNotFound();
            }
            return View(detallePo);
        }

        // GET: DetallePo/Create
        public ActionResult Create()
        {
            ViewBag.IdProductOrder = new SelectList(db.ProductOrder, "IdProductOrder", "Codigo");
            ViewBag.IdSuministro = new SelectList(db.Suministro, "IdSuministro", "Serie");
            return View();
        }

        // POST: DetallePo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdDetallePo,IdProductOrder,IdSuministro,cantidadPedido,CantidadRecibida,Pendiente,CantidadPendiente,Observacion")] DetallePo detallePo)
        {
            if (ModelState.IsValid)
            {
                db.DetallePo.Add(detallePo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdProductOrder = new SelectList(db.ProductOrder, "IdProductOrder", "Codigo", detallePo.IdProductOrder);
            ViewBag.IdSuministro = new SelectList(db.Suministro, "IdSuministro", "Serie", detallePo.IdSuministro);
            return View(detallePo);
        }

        // GET: DetallePo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePo detallePo = await db.DetallePo.FindAsync(id);
            if (detallePo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProductOrder = new SelectList(db.ProductOrder, "IdProductOrder", "Codigo", detallePo.IdProductOrder);
            ViewBag.IdSuministro = new SelectList(db.Suministro, "IdSuministro", "Serie", detallePo.IdSuministro);
            return View(detallePo);
        }

        // POST: DetallePo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdDetallePo,IdProductOrder,IdSuministro,cantidadPedido,CantidadRecibida,Pendiente,CantidadPendiente,Observacion")] DetallePo detallePo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallePo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdProductOrder = new SelectList(db.ProductOrder, "IdProductOrder", "Codigo", detallePo.IdProductOrder);
            ViewBag.IdSuministro = new SelectList(db.Suministro, "IdSuministro", "Serie", detallePo.IdSuministro);
            return View(detallePo);
        }

        // GET: DetallePo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePo detallePo = await db.DetallePo.FindAsync(id);
            if (detallePo == null)
            {
                return HttpNotFound();
            }
            return View(detallePo);
        }

        // POST: DetallePo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DetallePo detallePo = await db.DetallePo.FindAsync(id);
            db.DetallePo.Remove(detallePo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
