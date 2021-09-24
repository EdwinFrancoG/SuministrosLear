using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuministrosProject.Models;
using SuministrosProject.AppServices;

namespace SuministrosProject.Controllers
{
    public class LocalizacionsController : Controller
    {
        private SuministrosContext db = new SuministrosContext();
        public readonly LocationAppServices _locationAppServices = new LocationAppServices();

        // GET: Localizacions
        public async Task<ActionResult> Index()
        {
            return View(await db.Localizacion.ToListAsync());
        }

        // GET: Localizacions/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> Create([Bind(Include = "idLocalizacion,descripcion")] Localizacion localizacion)
        {
            var respuestaLocationAppServices = await _locationAppServices.AddLocation(localizacion);
            bool errorEnApservices = respuestaLocationAppServices != null;
            if (errorEnApservices)
            {
                return respuestaLocationAppServices;
            }
            else
            {
                return "OK";
            }

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

        [HttpPost]
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
