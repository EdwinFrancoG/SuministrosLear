using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuministrosProject.Domain
{
    public class ProductOrderDomain
    {
        public SuministrosContext db = new SuministrosContext();
        public string validarPO(ProductOrder productOrder)
        {
            bool modelIsEmpty = productOrder == null;
            if (modelIsEmpty)
            {
                return "Ingrese datos para ingresar una nueva PO";
            }

            var BuscarPO = db.ProductOrder.Where(p => p.Codigo == productOrder.Codigo).FirstOrDefault();
            bool POExist = BuscarPO != null;
            if (POExist)
            {
                return "El codigo de PO ingresado ya existe, por favor verifique la informacion";
            }

            bool codigoIsEmpty = productOrder.Codigo == null;
            if (codigoIsEmpty)
            {
                return "Ingrese el codigo de la PO";
            }

            bool requisicionIsEmpty = productOrder.Requisicion == null;
            if (requisicionIsEmpty)
            {
                return "Ingrese el numero de requisicion de la PO";
            }

            bool descriptionIsEmpty = productOrder.Descripcion == null;
            if (descriptionIsEmpty)
            {
                return "Ingrese la descripcion de la PO";
            }

            //productOrder.IdProductOrder = Convert.ToInt32(null);

            productOrder.Fecha = DateTime.Now;

            productOrder.Estado = "Nueva";


            return null;
        }
    }
}