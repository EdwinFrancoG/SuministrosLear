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
                return "Insert data, fields is empty";
            }

            var BuscarPO = db.ProductOrder.Where(p => p.Codigo == productOrder.Codigo).FirstOrDefault();
            bool POExist = BuscarPO != null;
            if (POExist)
            {
                return "The PO Code is alredy exist, please chek la information.";
            }

            bool codigoIsEmpty = productOrder.Codigo == null;
            if (codigoIsEmpty)
            {
                return "Insert the PO CODE";
            }

            bool requisicionIsEmpty = productOrder.Requisicion == null;
            if (requisicionIsEmpty)
            {
                return "Insert a requisition number of the PO";
            }

            bool descriptionIsEmpty = productOrder.Descripcion == null;
            if (descriptionIsEmpty)
            {
                return "Insert the description for product order";
            }

            //productOrder.IdProductOrder = Convert.ToInt32(null);

            productOrder.Fecha = DateTime.Now;

            productOrder.Estado = "Nueva";


            return null;
        }
    }
}
