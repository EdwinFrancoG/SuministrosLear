using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuministrosProject.Models;
using SuministrosProject.AppServices;

namespace SuministrosProject.Controllers
{
    public class UsuarioController : Controller
    {
        private SuministrosContext db = new SuministrosContext();

        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            var usuarios = db.Usuario.Include(u => u.IdPerfilNavigation);
            return View(await usuarios.ToListAsync());
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.IdPerfil = new SelectList(db.Perfil, "IdPerfil", "PerfilName");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdGafete,Nombre,Apellido,usuario,Estado,IdPerfil")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdPerfil = new SelectList(db.Perfil, "IdPerfil", "PerfilName", usuario.IdPerfil);
            return View(usuario);
        }



        // GET: Usuario/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPerfil = new SelectList(db.Perfil, "IdPerfil", "PerfilName", usuario.IdPerfil);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdGafete,Nombre,Apellido,usuario,Estado,IdPerfil")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdPerfil = new SelectList(db.Perfil, "IdPerfil", "PerfilName", usuario.IdPerfil);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Usuario usuario = await db.Usuario.FindAsync(id);
            db.Usuario.Remove(usuario);
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
