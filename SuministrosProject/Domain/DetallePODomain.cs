using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuministrosProject.Domain
{
    public class DetallePODomain
    {
        public SuministrosContext db = new SuministrosContext();
        public string validarDetallePO(DetallePo detallePo)
        {
            var cantidadPedido = detallePo.cantidadPedido;
            var cantidadPendiente = detallePo.CantidadPendiente;
            var cantidadRecibida = detallePo.CantidadRecibida;

            if (detallePo == null)
            {
                return "Por favor ingrese datos";
            }

            var buscarDetalle = db.DetallePo.Where(d=>d.IdProductOrder == detallePo.IdProductOrder && d.IdSuministro == detallePo.IdSuministro).FirstOrDefault();
            bool detalleExiste = buscarDetalle != null;

            if (detalleExiste)
            {
                return "Este suministro ya existe en esta PO";
            }

            bool cantidadPedidoEstaVacio = cantidadPedido == null;
            if (cantidadPedidoEstaVacio)
            {
                return "Ingrese la cantidad de suministros pedidos";
            }

            bool cantidadRecibidaEstaVacio = cantidadRecibida == 0;
            bool cantidadPendienteEstaVacio = cantidadPendiente == 0;
            if (cantidadRecibidaEstaVacio && cantidadPendienteEstaVacio)
            {
                return "Por favor ingrese informacion correcta en cantidad recibida y pendiente";
            }

            if (cantidadRecibida>cantidadPedido)
            {
                return "La cantidad recibide es mayor a la cantidad del pedido, por favor ingrese la informacion correcta";
            }

            if (cantidadPendiente>cantidadPedido)
            {
                return "La cantidad de suministros pendientes es incorrecta, es mayor a la cantidad del pedido";
            }

            if (!cantidadPendienteEstaVacio)
            {
                detallePo.Pendiente = true;
            }

            return null;
        }

    }
}