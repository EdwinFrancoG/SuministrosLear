using SuministrosProject.Domain;
using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuministrosProject.AppServices
{
    public class suministrosAppSerices
    {
        public SuministrosContext db = new SuministrosContext();
        private readonly suministroDomain _suministroDomain = new suministroDomain();

        public async Task<string> IngresarSuministro(Suministro suministro)
        {
            var respuestaSunministroDomain = _suministroDomain.validarSuministro(suministro);
            bool ErrorEnDomain = respuestaSunministroDomain != null;
            if (ErrorEnDomain)
            {
                return respuestaSunministroDomain;
            }

            try
            {
                db.Suministro.Add(suministro);
                await db.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return e.Message;
            }
            return null;
        }


        public async Task<string> eliminarSuministro(int id)
        {
            var respuestaSuministroDomain = _suministroDomain.validarEliminacion(id);
            bool errorRespuestaDomain = respuestaSuministroDomain != null;

            if (errorRespuestaDomain)
            {
                return respuestaSuministroDomain.ToString();
            }

            try
            {
                Suministro suministro = await db.Suministro.FindAsync(id);
                db.Suministro.Remove(suministro);
                await db.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}