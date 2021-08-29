using SuministrosProject.Domain;
using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuministrosProject.AppServices
{
    public class salidaAppServices
    {
        public SuministrosContext db = new SuministrosContext();
        public readonly salidaDomain _salidaDomain = new salidaDomain();
        public async Task<string> CrearSalidaSuministro(Salida salida, string serie)
        {
            var RespuestaSalidaDomain = await _salidaDomain.ValidarSalidaSuministro(salida, serie);
            bool errorEnDomain = RespuestaSalidaDomain != null;

            if (errorEnDomain)
            {
                return RespuestaSalidaDomain;
            }
            else
            {
                try
                {
                    db.Salida.Add(salida);
                    await db.SaveChangesAsync();
                    return null;
                }
                catch (Exception e)
                {
                    return e.InnerException.Message;
                }            
            }         
        }
    }
}