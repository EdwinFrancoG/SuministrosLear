using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuministrosProject.Domain
{
    public class DetallePODomain
    {
        public SuministrosContext db = new SuministrosContext();
        public async Task<string> validarDetallePO(DetallePo detallePo)
        {
            var BuscarNumeroParteEnDetallePO = db.DetallePo.Where(d => d.IdNumeroParte == detallePo.IdNumeroParte && d.IdProductOrder == detallePo.IdProductOrder).FirstOrDefault();
            var numeroDeparteExistenteEnPO = BuscarNumeroParteEnDetallePO != null;
            if (numeroDeparteExistenteEnPO)
            {
                return "Este numero de parte ya existe en esta orden de producto";
            }

            var cantidadPedido = detallePo.cantidadPedido;
            bool cantidadPedidoEstaVacio = cantidadPedido == null;
            if (cantidadPedidoEstaVacio)
            {
                return "Ingrese la cantidad de suministros pedidos";
            }

            int cantidadPendiente = Convert.ToInt32(detallePo.cantidadPedido);
            int idnumeroParte = Convert.ToInt32(detallePo.IdNumeroParte);

            detallePo.CantidadPendiente = cantidadPendiente;
            var respuestaAggStock = await aggStock(idnumeroParte, cantidadPendiente);
            bool ErrorAlAggStock = respuestaAggStock != null;
            if (ErrorAlAggStock)
            {
                return respuestaAggStock;
            }

            return null;
        }



        public async Task<string> aggStock(int numeroParte, int pendientes)
        {
            var NumeroParteEnstock = db.Stock.Where(d => d.IdNumeroParte == numeroParte).FirstOrDefault();
            bool NumeroParteEncontrado = NumeroParteEnstock != null;       
            if (NumeroParteEncontrado)
            {
                try
                {
                    int UpdatePendientes;
                    int UpdateCantidadTotal;
                    int cantidadPendientes = Convert.ToInt32(NumeroParteEnstock.Pendientes);
                    int cantidadTotal = Convert.ToInt32(NumeroParteEnstock.Total);

                    UpdatePendientes = cantidadPendientes + pendientes;
                    UpdateCantidadTotal = cantidadTotal + pendientes;

                    NumeroParteEnstock.Pendientes = UpdatePendientes;
                    NumeroParteEnstock.Total = UpdateCantidadTotal;

                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return e.InnerException.Message;
                }             
            }
            else
            {
                try
                {
                    Stock newStock = new Stock();
                    newStock.IdNumeroParte = numeroParte;
                    newStock.StockInicial = 0;
                    newStock.FechaInicio = DateTime.Now;
                    newStock.Entradas = 0;
                    newStock.Salidas = 0;
                    newStock.CantidadActual = 0;
                    newStock.Pendientes = pendientes;
                    newStock.Total = pendientes;
                    newStock.Estado = true;

                    db.Stock.Add(newStock);
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return e.InnerException.Message;
                }
            }
            return null;
        }


        public async Task<string> validarEliminacionDetallePO(int idDetPO)
        {
            var detallePO = db.DetallePo.Where(d => d.IdDetallePo == idDetPO).FirstOrDefault();
            int numeroParte = Convert.ToInt32(detallePO.IdNumeroParte);
            int pendientesDetallePO_a_restar = Convert.ToInt32(detallePO.CantidadPendiente);

            var NumeroParteEnstock = db.Stock.Where(d => d.IdNumeroParte == numeroParte).FirstOrDefault();

            try
            {
                int UpdatePendientes;
                int UpdateCantidadTotal;
                int cantidadPendientes = Convert.ToInt32(NumeroParteEnstock.Pendientes);
                int cantidadTotal = Convert.ToInt32(NumeroParteEnstock.Total);

                UpdatePendientes = cantidadPendientes - pendientesDetallePO_a_restar;
                UpdateCantidadTotal = cantidadTotal - pendientesDetallePO_a_restar;

                NumeroParteEnstock.Pendientes = UpdatePendientes;
                NumeroParteEnstock.Total = UpdateCantidadTotal;

                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {

                return e.Message;
            }

            return null;
        }

    }
}