using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuministrosProject.Models;
using System.Linq;

namespace SuministrosProject.Controllers
{
    public class NumeroParteController : Controller
    {
        private SuministrosContext db = new SuministrosContext();

        // GET: NumeroParte
        public async Task<ActionResult> Index()
        {
            var numeroPartes = db.NumeroParte.Include(n => n.IdCategoriaNavigation);
            return View(await numeroPartes.ToListAsync());
        }

        // GET: NumeroParte/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumeroParte numeroParte = await db.NumeroParte.FindAsync(id);
            if (numeroParte == null)
            {
                return HttpNotFound();
            }
            return View(numeroParte);
        }

        // GET: NumeroParte/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "CategoriaDescripcion");
            return View();
        }

        // POST: NumeroParte/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdNumeroParte,Descripcion,Modelo,Marca,IdCategoria,Observacion,Estado")] NumeroParte numeroParte)
        {
            if (ModelState.IsValid)
            {
                db.NumeroParte.Add(numeroParte);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "CategoriaDescripcion", numeroParte.IdCategoria);
            return View(numeroParte);
        }

        // GET: NumeroParte/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumeroParte numeroParte = await db.NumeroParte.FindAsync(id);
            if (numeroParte == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "CategoriaDescripcion", numeroParte.IdCategoria);
            return View(numeroParte);
        }

        // POST: NumeroParte/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdNumeroParte,Descripcion,Modelo,Marca,IdCategoria,Observacion,Estado")] NumeroParte numeroParte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numeroParte).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "CategoriaDescripcion", numeroParte.IdCategoria);
            return View(numeroParte);
        }

        // GET: NumeroParte/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumeroParte numeroParte = await db.NumeroParte.FindAsync(id);
            if (numeroParte == null)
            {
                return HttpNotFound();
            }
            return View(numeroParte);
        }

        // POST: NumeroParte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NumeroParte numeroParte = await db.NumeroParte.FindAsync(id);
            db.NumeroParte.Remove(numeroParte);
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
