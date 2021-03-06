using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuministrosProject.Models;
using SuministrosProject.AppServices;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SuministrosProject.Controllers
{
    public class SalidaController : Controller
    {
        private SuministrosContext db = new SuministrosContext();
        public readonly salidaAppServices _salidaAppServices = new salidaAppServices();

        // GET: Salida
        public async Task<ActionResult> Index()
        {
            var salidas = db.Salida.Include(s => s.IdEquipoNaviation).Include(s => s.IdSuministroNavigation);
            return View(await salidas.ToListAsync());
        }


        // GET: Salida/Create
        public ActionResult Create()
        {
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "equipo");
            ViewBag.IdSuministro = new SelectList(db.Suministro, "IdSuministro", "Serie");
            return View();
        }

        public ActionResult viewReportSalida()
        {
            return View();
        }

        public ActionResult ReportByNumberPart()
        {
            return View();
        }

        public ActionResult ReportByEquipment()
        {
            return View();
        }


        public ActionResult ReportSalidas(string startDate, string endDate, string numberPart, string equipment)
        {
            DateTime StartDate = DateTime.Parse(startDate);
            DateTime EndDate = DateTime.Parse(endDate);
            bool numberPartIsEmpty = numberPart == null;
            bool equipmeyIsEmpty = equipment == null;
            List<ReporteSalidaModel> ReporteSalidaSuministros = new List<ReporteSalidaModel>();

            try
            {

                if (numberPartIsEmpty && equipmeyIsEmpty)
                {

                    ReporteSalidaSuministros = (from s in db.Salida
                                                join sum in db.Suministro on s.IdSuministro equals sum.IdSuministro
                                                join np in db.NumeroParte on sum.IdNumeroParte equals np.IdNumeroParte
                                                join e in db.Equipo on s.idEquipo equals e.idEquipo

                                                where s.FechaSalida >= StartDate && s.FechaSalida <= EndDate.AddDays(1)
                                                orderby s.FechaSalida

                                                select new ReporteSalidaModel
                                                {
                                                    serieSuministro = sum.Serie,
                                                    numeroParte = np.Descripcion,
                                                    fechaSalida = Convert.ToString(s.FechaSalida),
                                                    equipo = e.equipo
                                                }).ToList();
                }

                if (!numberPartIsEmpty)
                {
                    ReporteSalidaSuministros = (from s in db.Salida
                                                join sum in db.Suministro on s.IdSuministro equals sum.IdSuministro
                                                join np in db.NumeroParte on sum.IdNumeroParte equals np.IdNumeroParte
                                                join e in db.Equipo on s.idEquipo equals e.idEquipo

                                                where np.Descripcion == numberPart &&
                                                s.FechaSalida >= StartDate && s.FechaSalida <= EndDate.AddDays(1)
                                                orderby s.FechaSalida

                                                select new ReporteSalidaModel
                                                {
                                                    serieSuministro = sum.Serie,
                                                    numeroParte = np.Descripcion,
                                                    fechaSalida = Convert.ToString(s.FechaSalida),
                                                    equipo = e.equipo
                                                }).ToList();
                }

                if (!equipmeyIsEmpty)
                {
                    ReporteSalidaSuministros = (from s in db.Salida
                                                join sum in db.Suministro on s.IdSuministro equals sum.IdSuministro
                                                join np in db.NumeroParte on sum.IdNumeroParte equals np.IdNumeroParte
                                                join e in db.Equipo on s.idEquipo equals e.idEquipo

                                                where e.equipo == equipment &&
                                                s.FechaSalida >= StartDate && s.FechaSalida <= EndDate.AddDays(1)
                                                orderby s.FechaSalida

                                                select new ReporteSalidaModel
                                                {
                                                    serieSuministro = sum.Serie,
                                                    numeroParte = np.Descripcion,
                                                    fechaSalida = Convert.ToString(s.FechaSalida),
                                                    equipo = e.equipo
                                                }).ToList();
                }
            }
            catch (System.Exception)
            {

                throw;
            }

            return View(ReporteSalidaSuministros);
        }

        // POST: Salida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<string> Create([Bind(Include = "IdSalida,IdSuministro,FechaSalida,idEquipo")] Salida salida, string serieSuministroID)
        {
            var respuestaAppServices = await _salidaAppServices.CrearSalidaSuministro(salida, serieSuministroID);
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

        // GET: Salida/Delete/5
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

        // POST: Salida/Delete/5
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
