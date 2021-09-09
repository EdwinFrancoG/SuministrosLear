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
    public class NumeroParteController : Controller
    {
        private SuministrosContext db = new SuministrosContext();
        public readonly NumeroParteAppSevices _numeroParteAppServices = new NumeroParteAppSevices();

        // GET: NumeroParte
        public async Task<ActionResult> Index()
        {
            var numeroPartes = db.NumeroParte.Include(n => n.IdCategoriaNavigation);
            return View(await numeroPartes.ToListAsync());
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
        public async Task<string> Create([Bind(Include = "IdNumeroParte,Descripcion,Modelo,Marca,IdCategoria,Observacion,Estado")] NumeroParte numeroParte)
        {
            var respuestaAppServices = await _numeroParteAppServices.ingresarNumeroParte(numeroParte);
            bool errorEnRespuesta = respuestaAppServices != null;
            if (errorEnRespuesta)
            {
                return respuestaAppServices;
            }
            else
            {
                return "OK";
            }
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
            NumeroParte numeroParte = await db.NumeroParte.Include(t=>t.IdCategoriaNavigation).FirstOrDefaultAsync(n=>n.IdNumeroParte == id);
            if (numeroParte == null)
            {
                return HttpNotFound();
            }
            return View(numeroParte);
        }

        // POST: NumeroParte/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<string> DeleteConfirmed(int id)
        {
            var respuestaAppServices = await _numeroParteAppServices.EliminarNumeroParte(id);
            bool errorEnRespuesta = respuestaAppServices != null;
            if (errorEnRespuesta)
            {
                return respuestaAppServices;
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
