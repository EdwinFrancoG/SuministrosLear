using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SuministrosProject.Models;

namespace SuministrosProject.Domain
{
    public class EntradaDomain
    {
        public SuministrosContext db = new SuministrosContext();
        public async Task<string> validarEntrada(Entrada entrada, int numeroParte, int idPO)
        {
            int idLocation = Convert.ToInt32(entrada.IdLocalizacion);
            bool serieIsEmpty = entrada.SerieSuministro == null;
            if (serieIsEmpty)
            {
                return "Favor ingresar la serie del suministro";
            }

            entrada.IdNumeroParte = numeroParte;

            //Respuesta al ingreso de suministros a la tabla suministros
            string serie = entrada.SerieSuministro;
            var respuestaAggSuministro = await aggSuministro(numeroParte, serie, idLocation);
            bool errorAlAggSuministro = respuestaAggSuministro != null;
            if (errorAlAggSuministro)
            {
                return respuestaAggSuministro;
            }

            //Respuesta del metodo que resta los pendientes en la tabla de detalle de PO           
            var RespuestaRestarEnDetallePO = await restarEnDetallePO(numeroParte, idPO);
            bool errorRestarEnDetalle = RespuestaRestarEnDetallePO != null;
            if (errorRestarEnDetalle)
            {
                return RespuestaRestarEnDetallePO;
            }

            //Respuesta al sumar en el stock de suministros          
            var respuestaSumarStock = await sumarStock(numeroParte, idLocation);
            bool errorEnRespuestaStock = respuestaSumarStock != null;
            if (errorEnRespuestaStock)
            {
                return respuestaSumarStock;
            }

            return null;
        }




        public async Task<string> restarEnDetallePO(int numeroParte, int idPO)
        {
            var DetallePO = db.DetallePo.Where(d => d.IdNumeroParte == numeroParte && d.IdProductOrder == idPO).FirstOrDefault();
            bool DetalleEncontrado = DetallePO != null;

            if (DetalleEncontrado)
            {
                try
                {
                    int pendientes = Convert.ToInt32(DetallePO.CantidadPendiente);
                    int pendienteActualizado;

                    pendienteActualizado = pendientes - 1;

                    DetallePO.CantidadPendiente = pendienteActualizado;
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {

                    return e.Message;
                }
                
            }
            else
            {
                return "No se encontro este Numero de Parte en la PO";
            }
            return null;
        }

        public async Task<string> aggSuministro(int numeroParte, string serie, int location)
        {
            try
            {
                Suministro suministro = new Suministro();
                suministro.Serie = serie;
                suministro.IdNumeroParte = Convert.ToInt32(numeroParte);
                suministro.IdLocalizacion = location;
                suministro.Estado = true;

                db.Suministro.Add(suministro);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {

                return e.InnerException.Message;
            }
            return null;
        }

        public async Task<string> sumarStock(int numeroParte, int idLocation)
        {
            var NumeroParteEnStock = db.Stock.Where(s => s.IdNumeroParte == numeroParte).FirstOrDefault();
            int entradas = Convert.ToInt32(NumeroParteEnStock.Entradas);
            int pendientes = Convert.ToInt32(NumeroParteEnStock.Pendientes);
            int cantidadActual = Convert.ToInt32(NumeroParteEnStock.CantidadActual);
            int stockInicio = Convert.ToInt32(NumeroParteEnStock.StockInicial);
            int stockSalidas = Convert.ToInt32(NumeroParteEnStock.Salidas);
            int newEntradas;
            int newPendientes;
            int cantidadActualUpdate;

            bool numeroDeParteNoExisteEnStock = NumeroParteEnStock == null;
            if (numeroDeParteNoExisteEnStock)
            {
                try
                {
                    Stock newStock = new Stock();
                    newStock.IdNumeroParte = numeroParte;
                    newStock.StockInicial = 0;
                    newStock.FechaInicio = DateTime.Now;
                    newStock.Entradas = 1;
                    newStock.Salidas = 0;
                    newStock.CantidadActual = 1;
                    newStock.Pendientes = 1;
                    newStock.Total = 1;
                    newStock.Estado = true;

                    db.Stock.Add(newStock);
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
                
            }
            else
            {
                try
                {
                    newEntradas = entradas + 1;
                    newPendientes = pendientes - 1;
                    cantidadActualUpdate = (stockInicio + newEntradas) - stockSalidas;
                    NumeroParteEnStock.Entradas = newEntradas;
                    NumeroParteEnStock.Pendientes = newPendientes;
                    NumeroParteEnStock.CantidadActual = cantidadActualUpdate;
                    NumeroParteEnStock.Total = cantidadActualUpdate + newPendientes;

                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {

                    return e.Message;
                }                
            }
            return null;
        }
    }
}