using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuministrosProject.Models;

namespace SuministrosProject.Domain
{
    public class categoriasDomain
    {
        public categoriasDomain()
        {

        }

        public string validarIngresoCaetegoria(Categoria categoria)
        {
            bool isModelEmpty = categoria == null;
            if (isModelEmpty)
            {
                return "The fields are empty, please enter data correctly";
            }

            bool descripcionIsEmpty = categoria.CategoriaDescripcion == null;
            if (descripcionIsEmpty)
            {
                return "Insert a type description";
            }

            bool observacionIsEmpty = categoria.Observacion == null;
            if (observacionIsEmpty)
            {
                return "Insert a observation of the type";
            }
            categoria.Estado = true;
            return null;
        }
    }
}
