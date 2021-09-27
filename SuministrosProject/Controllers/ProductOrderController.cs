using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuministrosProject.Models;
using SuministrosProject.AppServices;

namespace SuministrosProject.Controllers
{
    public class ProductOrderController : Controller
    {
        private SuministrosContext db = new SuministrosContext();
        public readonly ProductOrderAppServices POAppServices = new ProductOrderAppServices();

        // GET: ProductOrder
        public async Task<ActionResult> Index()
        {
            var productOrders = db.ProductOrder.Include(p => p.IdGafeteNavigation);
            return View(await productOrders.ToListAsync());
        }

        // GET: ProductOrder/Create
        public ActionResult Create()
        {
            ViewBag.IdGafete = new SelectList(db.Usuario, "IdGafete", "IdGafete");

            return View();
        }


        [HttpPost]
        public async Task<string> Create([Bind(Include = "IdProductOrder,Codigo,Requisicion,Descripcion,Fecha,IdGafete,Estado")] ProductOrder productOrder)
        {
            var RespuestaPOAppServices = await POAppServices.InsertarPO(productOrder);
            bool ingresoIncorrecto = RespuestaPOAppServices != null;

            if (ingresoIncorrecto)
            {
                return RespuestaPOAppServices.ToString();
            }
            else
            {
                return "OK";
            }
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
            ProductOrder productOrder = await db.ProductOrder.Include(u=>u.IdGafeteNavigation).FirstOrDefaultAsync(p=>p.IdProductOrder == id);
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
