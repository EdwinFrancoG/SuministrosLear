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
                return "Los campos estan vacios porfavor ingrese datos correctamente";
            }

            bool descripcionIsEmpty = categoria.CategoriaDescripcion == null;
            if (descripcionIsEmpty)
            {
                return "Ingrese una descripcion";
            }

            bool observacionIsEmpty = categoria.Observacion == null;
            if (observacionIsEmpty)
            {
                return "Ingrese una observacion";
            }
            categoria.Estado = true;
            return null;
        }
    }
}
