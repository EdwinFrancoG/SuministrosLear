using Microsoft.Data.Entity;
using SuministrosProject.Domain;
using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace SuministrosProject.AppServices
{
    public class NumeroParteAppSevices
    {
        public SuministrosContext db = new SuministrosContext();
        public readonly NumeroParteDomain _PNDomain = new NumeroParteDomain();

        public async Task<string> ingresarNumeroParte(NumeroParte _numeroParte)
        {
            var respuestaDomain = _PNDomain.validarInsercionNumeroParte(_numeroParte);
            bool errorEnDomain = respuestaDomain != null;
            if (errorEnDomain)
            {
                return respuestaDomain;
            }
            else
            {
                try
                {
                    db.NumeroParte.Add(_numeroParte);
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return e.InnerException.Message;
                }
            }
            return null;
        }


        public async Task<string> EliminarNumeroParte(int idNumeroParte)
        {
            var respuestaAeliminacionEnDoamin = _PNDomain.validarEliminacion();
            bool errorEnRespuesta = respuestaAeliminacionEnDoamin != null;
            if (errorEnRespuesta)
            {
                return respuestaAeliminacionEnDoamin;
            }
            else
            {
                try
                {
                    NumeroParte numeroParte = await db.NumeroParte.FindAsync(idNumeroParte);
                    db.NumeroParte.Remove(numeroParte);
                    await db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return "This part number is using in stock or a product order";
                }
            }
            return null;
        }
    }
}
