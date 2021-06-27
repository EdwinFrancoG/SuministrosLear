using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuministrosProject.Models;

namespace SuministrosProject.Controllers
{
    public class ProductOrderController : Controller
    {
        private SuministrosContext db = new SuministrosContext();

        // GET: ProductOrder
        public async Task<ActionResult> Index()
        {
            var productOrders = db.ProductOrder.Include(p => p.IdGafeteNavigation);
            return View(await productOrders.ToListAsync());
        }

        // GET: ProductOrder/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrder productOrder = await db.ProductOrder.FindAsync(id);
            if (productOrder == null)
            {
                return HttpNotFound();
            }
            return View(productOrder);
        }

        // GET: ProductOrder/Create
        public ActionResult Create()
        {
            ViewBag.IdGafete = new SelectList(db.Usuario, "IdGafete", "Nombre");
            return View();
        }

        // POST: ProductOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdProductOrder,Codigo,Requisicion,Descripcion,Fecha,IdGafete,Estado")] ProductOrder productOrder)
        {
            if (ModelState.IsValid)
            {
                db.ProductOrder.Add(productOrder);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdGafete = new SelectList(db.Usuario, "IdGafete", "Nombre", productOrder.IdGafete);
            return View(productOrder);
        }

        // GET: ProductOrder/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrder productOrder = await db.ProductOrder.FindAsync(id);
            if (productOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGafete = new SelectList(db.Usuario, "IdGafete", "Nombre", productOrder.IdGafete);
            return View(productOrder);
        }

        // POST: ProductOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdProductOrder,Codigo,Requisicion,Descripcion,Fecha,IdGafete,Estado")] ProductOrder productOrder)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(productOrder).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdGafete = new SelectList(db.Usuario, "IdGafete", "Nombre", productOrder.IdGafete);
            return View(productOrder);
        }

        // GET: ProductOrder/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrder productOrder = await db.ProductOrder.FindAsync(id);
            if (productOrder == null)
            {
                return HttpNotFound();
            }
            return View(productOrder);
        }

        // POST: ProductOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductOrder productOrder = await db.ProductOrder.FindAsync(id);
            db.ProductOrder.Remove(productOrder);
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
