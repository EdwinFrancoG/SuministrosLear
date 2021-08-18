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
    public class SuministroController : Controller
    {
        private SuministrosContext db = new SuministrosContext();
        private readonly suministrosAppSerices _suministrosAppSerices = new suministrosAppSerices();

        // GET: Suministro
        public async Task<ActionResult> Index()
        {
            var suministroes = db.Suministro.Where(s=>s.Estado == true).Include(s => s.IdNumeroParteNavigation);
            return View(await suministroes.ToListAsync());
        }

        // GET: Suministro/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var suministro = await db.Suministro.Include(c => c.IdNumeroParteNavigation).FirstOrDefaultAsync(c=>c.IdSuministro == id);

            if (suministro == null)
            {
                return HttpNotFound();
            }
            return View(suministro);
        }

        // GET: Suministro/Create
        public ActionResult Create()
        {
            ViewBag.IdNumeroParte = new SelectList(db.NumeroParte, "IdNumeroParte", "Descripcion");
            return View();
        }

        // POST: Suministro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<string> Create([Bind(Include = "IdSuministro,Serie,IdNumeroParte,Estado")] Suministro suministro)
        {
            var respuestaSuministroAppServices = await _suministrosAppSerices.IngresarSuministro(suministro);
            bool ingresoIncorrecto = respuestaSuministroAppServices != null;
            if (ingresoIncorrecto)
            {
                return respuestaSuministroAppServices.ToString();
            }
            else
            {
                return "OK";
            }
        }

        // GET: Suministro/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suministro suministro = await db.Suministro.FindAsync(id);
            if (suministro == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdNumeroParte = new SelectList(db.NumeroParte, "IdNumeroParte", "Descripcion", suministro.IdNumeroParte);
            return View(suministro);
        }

        // POST: Suministro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdSuministro,Serie,IdNumeroParte,Estado")] Suministro suministro)
        {
            if (ModelState.IsValid)
            {
                db.Update(suministro);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdNumeroParte = new SelectList(db.NumeroParte, "IdNumeroParte", "Descripcion", suministro.IdNumeroParte);
            return View(suministro);
        }

        // GET: Suministro/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suministro suministro = await db.Suministro.FindAsync(id);
            if (suministro == null)
            {
                return HttpNotFound();
            }
            return View(suministro);
        }

        // POST: Suministro/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<string> DeleteConfirmed(int id)
        {
            var respuestaSuministroAppServices = await _suministrosAppSerices.eliminarSuministro(id);
            if (respuestaSuministroAppServices != null)
            {
                return respuestaSuministroAppServices;
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
