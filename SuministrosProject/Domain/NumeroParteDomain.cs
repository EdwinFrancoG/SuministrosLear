using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuministrosProject.Models;

namespace SuministrosProject.Domain
{
    public class NumeroParteDomain
    {
        public string validarInsercionNumeroParte(NumeroParte _numeroParte)
        {
            bool descripcionEstaVacio = _numeroParte.Descripcion == null;
            if (descripcionEstaVacio)
            {
                return "Insert the part number description";
            }

            bool marcaEstaVacio = _numeroParte.Marca == null;
            if (marcaEstaVacio)
            {
                return "Please, Insert the part number brand";
            }

            _numeroParte.Estado = true;
            return null;
        }


        public string validarEliminacion()
        {
            return null;
        }
    }
}
