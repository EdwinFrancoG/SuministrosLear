using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuministrosProject.Models;
using SuministrosProject.AppServices;

namespace SuministrosProject.Controllers
{
    public class EntradaController : Controller
    {
        private SuministrosContext db = new SuministrosContext();
        public readonly EntradaAppServices _entradaAppServices = new EntradaAppServices();

        // GET: Entrada
        public async Task<ActionResult> Index()
        {
            var entradas = db.Entrada.Include(e => e.IdNumeroParteNavigation).Include(l=>l.IdLocalizacionNavigation);
            return View(await entradas.ToListAsync());
        }

        // GET: Entrada/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = await db.Entrada.FindAsync(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        // GET: Entrada/Create
        public ActionResult CreateEntrada(int numeroDeParte, int idPO)
        {
            ViewBag.IdNumeroParte = numeroDeParte;
            ViewBag.IdPO = idPO;
            ViewBag.idLocalizacion = new SelectList(db.Localizacion, "idLocalizacion", "descripcion");
            return View();
        }

        // POST: Entrada/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        public async Task<string> Create([Bind(Include = "IdEntrada,SerieSuministro,IdNumeroParte,IdLocalizacion")] Entrada entrada, int numeroParte, int idPO)
        {
            var respuestaEntradaServices = await _entradaAppServices.insertarEntrada(entrada, numeroParte, idPO);
            bool ingresoIncorrecto = respuestaEntradaServices != null;
            if (ingresoIncorrecto)
            {
                return respuestaEntradaServices;
            }
            else
            {
                return "OK";
            }
        }

        // GET: Entrada/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = await db.Entrada.FindAsync(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdNumeroParte = new SelectList(db.NumeroParte, "IdNumeroParte", "Descripcion", entrada.IdNumeroParte);
            ViewBag.IdLocalizacion = new SelectList(db.Localizacion, "IdLocalizacion", "descripcion", entrada.IdLocalizacion);
            return View(entrada);
        }

        // POST: Entrada/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdEntrada,SerieSuministro,IdNumeroParte,IdLocalizacion")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrada).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdNumeroParte = new SelectList(db.NumeroParte, "IdNumeroParte", "Descripcion", entrada.IdNumeroParte);
            ViewBag.IdLocalizacion = new SelectList(db.Localizacion, "IdLocalizacion", "descripcion", entrada.IdLocalizacion);
            return View(entrada);
        }

        // GET: Entrada/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = await db.Entrada.FindAsync(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        // POST: Entrada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Entrada entrada = await db.Entrada.FindAsync(id);
            db.Entrada.Remove(entrada);
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
