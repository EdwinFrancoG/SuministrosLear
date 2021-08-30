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
            var DescriptionIsNull = localizacion.descripcion == null;
            if (DescriptionIsNull)
            {
                return "Por favor ingrese una descripción";
            }
            return null;
        }
    }
}