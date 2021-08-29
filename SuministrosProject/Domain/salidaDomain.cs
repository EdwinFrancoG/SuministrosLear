using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuministrosProject.Domain
{
    public class salidaDomain
    {
        public SuministrosContext db = new SuministrosContext();
        public async Task<string> ValidarSalidaSuministro(Salida salida, string serie)
        {
            bool serieEstaVacio = serie == null;
            if (serieEstaVacio)
            {
                return "Ingrese la serie del suministro";
            }

            salida.FechaSalida = DateTime.Now;

            var registroSuministro = db.Suministro.Where(s => s.Serie == serie).FirstOrDefault();
            if (registroSuministro == null)
            {
                return "Esta serie de suministro no esta en existencia";
            }
            int numeroParte = Convert.ToInt32(registroSuministro.IdNumeroParte);

            var respuestaRebajarEnStock = await RebajarEnStock(numeroParte);
            bool errorAlRebajarEnStock = respuestaRebajarEnStock != null;
            if (errorAlRebajarEnStock)
            {
                return respuestaRebajarEnStock;
            }

            var respuestaDarDeBajaEnSuministro = await DarDeBajaEnSuministro(serie);
            bool errorDarDeBajaEnSuministro = respuestaDarDeBajaEnSuministro != null;
            if (errorDarDeBajaEnSuministro)
            {
                return respuestaDarDeBajaEnSuministro;
            }

            salida.IdSuministro = Convert.ToInt32(registroSuministro.IdSuministro);

            return null;
        }




        public async Task<string> DarDeBajaEnSuministro(string serie)
        {
            var Suministro = db.Suministro.Where(s => s.Serie == serie).FirstOrDefault();
            bool SuministroNoEncontrado = Suministro == null;

            if (!SuministroNoEncontrado)
            {
                Suministro.Estado = false;
                await db.SaveChangesAsync();
            }

            return null;
        }




        public async Task<string> RebajarEnStock(int numeroParte)
        {
            try
            {
                var numeroParteEnStock = db.Stock.Where(s => s.IdNumeroParte == numeroParte).FirstOrDefault();
                int salidas = Convert.ToInt32(numeroParteEnStock.Salidas);
                int cantidadActual = Convert.ToInt32(numeroParteEnStock.CantidadActual);
                int pendientes = Convert.ToInt32(numeroParteEnStock.Pendientes);
                int stockIniscial = Convert.ToInt32(numeroParteEnStock.StockInicial);
                int entradas = Convert.ToInt32(numeroParteEnStock.Entradas);
                int total = Convert.ToInt32(numeroParteEnStock.Total);

                if (cantidadActual <= 0)
                {
                    return "No hay suministros en stock de este numero de parte";
                }

                int salidasUpdate; int cantidadActualUpdate; int totalUpdate;

                salidasUpdate = salidas + 1;
                cantidadActualUpdate = (stockIniscial + entradas) - salidasUpdate;
                totalUpdate = cantidadActualUpdate + pendientes;

                numeroParteEnStock.Salidas = salidasUpdate;
                numeroParteEnStock.CantidadActual = cantidadActualUpdate;
                numeroParteEnStock.Total = totalUpdate;

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