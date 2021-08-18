using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuministrosProject.Models;

namespace SuministrosProject.Controllers
{
    public class SalidasController : Controller
    {
        private SuministrosContext db = new SuministrosContext();

        // GET: Salidas
        public async Task<ActionResult> Index()
        {
            var salidas = db.Salida.Include(s => s.IdSuministroNavigation);
            return View(await salidas.ToListAsync());
        }

        // GET: Salidas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = await db.Salida.FindAsync(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // GET: Salidas/Create
        public ActionResult Create()
        {
            ViewBag.IdSuministro = new SelectList(db.Suministro, "IdSuministro", "Serie");
            return View();
        }

        // POST: Salidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdSalida,IdSuministro,Equipo,FechaSalida")] Salida salida)
        {
            if (ModelState.IsValid)
            {
                db.Salida.Add(salida);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdSuministro = new SelectList(db.Suministro, "IdSuministro", "Serie", salida.IdSuministro);
            return View(salida);
        }

        // GET: Salidas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = await db.Salida.FindAsync(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // POST: Salidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Salida salida = await db.Salida.FindAsync(id);
            db.Salida.Remove(salida);
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
