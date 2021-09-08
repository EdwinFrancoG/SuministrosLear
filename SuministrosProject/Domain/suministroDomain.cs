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
            //variables para busqueda de suministro en listado de suministros y en el stock
            var suministro = db.Suministro.Where(s => s.IdSuministro == id).FirstOrDefault();
            var numeroParteSuministro = suministro.IdNumeroParte;
            var numeroParteEnStock = db.Stock.Where(n => n.IdNumeroParte == numeroParteSuministro).FirstOrDefault();

            //variables de stock para calculos
            int salidas = Convert.ToInt32(numeroParteEnStock.Salidas);
            int cantidadActual = Convert.ToInt32(numeroParteEnStock.CantidadActual);
            int pendientes = Convert.ToInt32(numeroParteEnStock.Pendientes);
            int stockIniscial = Convert.ToInt32(numeroParteEnStock.StockInicial);
            int entradas = Convert.ToInt32(numeroParteEnStock.Entradas);
            int total = Convert.ToInt32(numeroParteEnStock.Total);

            //Calculos al elimininar un suministro
            if (cantidadActual <= 0)
            {
                return "No hay suministros en stock de este numero de parte";
            }
            else
            {
                int salidasUpdate; int cantidadActualUpdate; int totalUpdate;

                salidasUpdate = salidas + 1;
                cantidadActualUpdate = (stockIniscial + entradas) - salidasUpdate;
                totalUpdate = cantidadActualUpdate + pendientes;

                numeroParteEnStock.Salidas = salidasUpdate;
                numeroParteEnStock.CantidadActual = cantidadActualUpdate;
                numeroParteEnStock.Total = totalUpdate;

                db.SaveChangesAsync();
                return null;
            }
        }
    }
}
