using SuministrosProject.Domain;
using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuministrosProject.AppServices
{
    public class DetallePOAppServices
    {
        public SuministrosContext db = new SuministrosContext();
        public readonly DetallePODomain _detalle = new DetallePODomain();

        public async Task<string> ingresarDetallePO(DetallePo detallePo)
        {
            var respuestaDomainDetPO = await _detalle.validarDetallePO(detallePo);
            bool ErrorEnRespuestaDetPo = respuestaDomainDetPO != null;
            if (ErrorEnRespuestaDetPo)
            {
                return respuestaDomainDetPO;
            }

            try
            {
                db.DetallePo.Add(detallePo);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
               return e.InnerException.Message;
            }
            return null;
        }

        public async Task<int> eliminarDetPO(int idDetPO)
        {
            var respuestaEliminarDetallePODomain = await _detalle.validarEliminacionDetallePO(idDetPO);
            bool errorRespuestaDomain = respuestaEliminarDetallePODomain != null;
            if (!errorRespuestaDomain)
            {
                DetallePo detallePo = await db.DetallePo.FindAsync(idDetPO);
                int idPO = Convert.ToInt32(detallePo.IdProductOrder);
                db.DetallePo.Remove(detallePo);
                await db.SaveChangesAsync();

                return idPO;
            }
            else
            {
                return 0;
            }                 
        }

        public string estadoPendiente(int idProductOrder)
        {
            var PO = db.ProductOrder.Where(p => p.IdProductOrder == idProductOrder).FirstOrDefault();
            PO.Estado = "Pendiente";

            db.SaveChanges();

            return null;
        }

        public string estadoCerrada(int idProductOrder)
        {
            var PO = db.ProductOrder.Where(p => p.IdProductOrder == idProductOrder).FirstOrDefault();
            PO.Estado = "Cerrada";

            db.SaveChanges();

            return null;
        }
    }
}