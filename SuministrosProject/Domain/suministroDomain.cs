using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuministrosProject.Domain
{
    public class suministroDomain
    {
        public SuministrosContext db = new SuministrosContext();

        public string validarSuministro(Suministro suministro)
        {
            bool suministroIsEmpty = suministro == null;
            if (suministroIsEmpty)
            {
                return "Los campos estan vacios";
            }

            bool descripcionIsEmpty = suministro.Descripcion == null;
            if (descripcionIsEmpty)
            {
                return "Por favor inGrese la descripción del suministro";
            }

            bool modeloIsEmpty = suministro.Modelo == null;
            if (modeloIsEmpty)
            {
                return "Por favor ingrese el modelo del suministro";
            }

            bool serieIsEmpty = suministro.Serie == null;
            if (serieIsEmpty)
            {
               return "Ingrese la serie del suministro";
            }

            bool numeroParteIsEmpty = suministro.NumeroParte == null;
            if (numeroParteIsEmpty)
            {
                return "Ingrese el numero de parte del suministro";
            }

            bool state = true;
            suministro.Estado = state;

            return null;
        }


        public string validarEliminacion(int id)
        {
            var buscarExistencia = db.Stock.Where(s => s.IdSuministro == id).FirstOrDefault();
            bool existeEnExistencia = buscarExistencia != null;
            if (existeEnExistencia)
            {
                return "No se puede eliminar porque aun hay existencia de este suministro";
            }
            return null;
        }
    }
}