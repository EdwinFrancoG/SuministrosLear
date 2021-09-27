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
            var entradas = db.Entrada.Include(e => e.IdNumeroParteNavigation).Include(l=>l.IdLocalizacionNavigation).Include(p=>p.IdProductOrderNavigation);
            return View(await entradas.ToListAsync());
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
        public async Task<string> Create([Bind(Include = "IdEntrada,SerieSuministro,IdNumeroParte,IdLocalizacion,fechaEntrada,IdPO")] Entrada entrada, int numeroParte, int idPO)
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
