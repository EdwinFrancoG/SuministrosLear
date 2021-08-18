using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuministrosProject.Models;
using SuministrosProject.Domain;
using System.Threading.Tasks;

namespace SuministrosProject.AppServices
{
    public class EntradaAppServices
    {
        public SuministrosContext db = new SuministrosContext();
        public readonly EntradaDomain _entradaDomain = new EntradaDomain();

        public async Task<string> insertarEntrada(Entrada entrada, int numeroParte, int idPO)
        {
            var respuestaEntradaDomain = await _entradaDomain.validarEntrada(entrada, numeroParte, idPO);
            bool ErrorEnDomain = respuestaEntradaDomain != null;
            if (ErrorEnDomain)
            {
                return respuestaEntradaDomain;
            }

            try
            {
                db.Entrada.Add(entrada);
                await db.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return e.Message;
            }
            return null;
        }
    }
}