using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using SuministrosProject.Models;
using SuministrosProject.AppServices;
using System.Web.Mvc.Html;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SuministrosProject.Controllers
{
    public class CategoriasController : Controller
    {
        
        public readonly SuministrosContext db = new SuministrosContext();
        public readonly CategoriasAppServices _CategoriaAppS = new CategoriasAppServices();

        public async Task<ActionResult> Index()
        {
            return View(await db.Categoria.ToListAsync());
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> create([Bind(Include = "IdCategoria,CategoriaDescripcion,Observacion,Estado")] Categoria categoria)
        {
            var respuestaCategoriaServices = await _CategoriaAppS.IngresarCategoria(categoria);
            bool ingresoIncorrecto = respuestaCategoriaServices != null;
            if (ingresoIncorrecto)
            {
                return respuestaCategoriaServices.ToString();
            }
            else
            {
                return "OK";
            }
        }


        // GET: Categorias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = await db.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdCategoria,CategoriaDescripcion,Observacion,Estado")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = await db.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Categoria categoria = await db.Categoria.FindAsync(id);
            db.Categoria.Remove(categoria);
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
