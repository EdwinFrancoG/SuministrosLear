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

            var buscarSumiistro = db.Suministro.Where(s => s.Serie == suministro.Serie).FirstOrDefault();
            bool suministroExiste = buscarSumiistro != null;
            if (suministroExiste)
            {
                return "Este suministro ya fue creado interiormente, revise que la serie este correctamente";
            }

            bool serieIsEmpty = suministro.Serie == null;
            if (serieIsEmpty)
            {
                return "Ingrese la serie del suministro";
            }                       

            bool state = true;
            suministro.Estado = state;

            return null;
        }


        public string validarEliminacion(int id)
        {
            //var buscarExistencia = db.Stock.Where(s => s.IdSuministro == id).FirstOrDefault();
            //bool existeEnExistencia = buscarExistencia != null;
            //if (existeEnExistencia)
            //{
            //    return "No se puede eliminar porque aun hay existencia de este suministro";
            //}
            return null;
        }
    }
}