using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuministrosProject.Models;
using System.Linq;
using SuministrosProject.AppServices;

namespace SuministrosProject.Controllers
{
    public class DetallePoController : Controller
    {
        private SuministrosContext db = new SuministrosContext();
        public readonly DetallePOAppServices _detallePOAppServices = new DetallePOAppServices();

        // GET: DetallePo
        public async Task<ActionResult> Index(int? idProdOrder)
        {
            var PO = db.ProductOrder.Where(p => p.IdProductOrder == idProdOrder).FirstOrDefault();
            ViewBag.idPO = PO.IdProductOrder;
            ViewData["PO"] = PO.Codigo;
            ViewData["estado"] = PO.Estado;
            ViewData["fecha"] = PO.Fecha;
            ViewData["req"] = PO.Requisicion;
            var verDetallePO = db.DetallePo.Where(d => d.IdProductOrder == idProdOrder).Include(d => d.IdNumeroParteNavigation).Include(c=>c.IdProductOrderNavigation);
            return View(await verDetallePO.ToListAsync());
        }

        public ActionResult cambiarEstadoAPendiente(int idPO)
        {
            var RespuestaAppSerices = _detallePOAppServices.estadoPendiente(idPO);
            if (RespuestaAppSerices == null)
            {
                return  RedirectToRoute("RoutePO");
            }
            return null;
        }

        public ActionResult cambiarEstadoACerrada(int idPO)
        {
            var RespuestaAppSerices = _detallePOAppServices.estadoCerrada(idPO);
            if (RespuestaAppSerices == null)
            {
                return RedirectToRoute("RoutePO");
            }
            return null;
        }

        // GET: DetallePo/Create
        public ActionResult Create(int idProdOrder)
        {
            ViewBag.IdProductOrder = idProdOrder;
            ViewBag.IdNumeroParte = new SelectList(db.NumeroParte, "IdNumeroParte", "Descripcion");          
            return View();
        }

        // POST: DetallePo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<string> Create([Bind(Include = "IdDetallePo,IdProductOrder,IdNumeroParte,cantidadPedido,CantidadPendiente,Observacion")] DetallePo detallePo)
        {
            var respuestaAppServices = await _detallePOAppServices.ingresarDetallePO(detallePo);
            bool errorRespuestaAppServices = respuestaAppServices != null;
            if (errorRespuestaAppServices)
            {
                return respuestaAppServices;
            }
            else
            {
                return "OK";
            }
        }

        // GET: DetallePo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePo detallePo = await db.DetallePo.Where(d=>d.IdDetallePo == id).Include(d=>d.IdNumeroParteNavigation).Include(d=>d.IdProductOrderNavigation).FirstOrDefaultAsync();
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
            var idPO = await  _detallePOAppServices.eliminarDetPO(id);
            return RedirectToAction("Index", new { idProdOrder = idPO });
            //return RedirectToRoute("IndexDetPO" + "/?idProdOrder=" + idPO);
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
