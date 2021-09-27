using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuministrosProject.Models;

namespace SuministrosProject.Domain
{
    public class LocationDomain
    {
        public string validarLocation(Localizacion localizacion)
        {
            var DescripcionIsNull = localizacion.descripcion == null;
            if (DescripcionIsNull)
            {
                return "Please insert data in the filed of location";
            }
            return null;
        }
    }
}
