using SuministrosProject.Domain;
using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace SuministrosProject.AppServices
{
    public class LocationAppServices
    {
        public SuministrosContext db = new SuministrosContext();
        public readonly LocationDomain _Location = new LocationDomain();

        public async Task<string> AddLocation(Localizacion localizacion)
        {
            var respuestaDomainLocation = _Location.validarLocation(localizacion);
            bool errorEnDomain = respuestaDomainLocation != null;
            if (errorEnDomain)
            {
                return respuestaDomainLocation;
            }

            var busacarLocalizacion = db.Localizacion.Where(l => l.descripcion == localizacion.descripcion).FirstOrDefault();
            bool localizacionExiste = busacarLocalizacion != null;

            if (localizacionExiste)
            {
                return "Esta descripcion de localizacion ya existe";
            }

            try
            {
                db.Localizacion.Add(localizacion);
                await db.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {
               return  e.InnerException.Message;
            }        
        }
    }
}
