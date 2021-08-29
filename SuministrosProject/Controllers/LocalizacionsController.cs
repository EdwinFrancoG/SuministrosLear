using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuministrosProject.Models;

namespace SuministrosProject.Controllers
{
    public class LocalizacionsController : Controller
    {
        private SuministrosContext db = new SuministrosContext();

        // GET: Localizacions
        public async Task<ActionResult> Index()
        {
            return View(await db.Localizacion.ToListAsync());
        }

        // GET: Localizacions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localizacion localizacion = await db.Localizacion.FindAsync(id);
            if (localizacion == null)
            {
                return HttpNotFound();
            }
            return View(localizacion);
        }

        // GET: Localizacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Localizacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idLocalizacion,descripcion")] Localizacion localizacion)
        {
            if (ModelState.IsValid)
            {
                db.Localizacion.Add(localizacion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(localizacion);
        }

        // GET: Localizacions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localizacion localizacion = await db.Localizacion.FindAsync(id);
            if (localizacion == null)
            {
                return HttpNotFound();
            }
            return View(localizacion);
        }

        // POST: Localizacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idLocalizacion,descripcion")] Localizacion localizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localizacion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(localizacion);
        }

        // GET: Localizacions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localizacion localizacion = await db.Localizacion.FindAsync(id);
            if (localizacion == null)
            {
                return HttpNotFound();
            }
            return View(localizacion);
        }

        // POST: Localizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Localizacion localizacion = await db.Localizacion.FindAsync(id);
            db.Localizacion.Remove(localizacion);
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
