using SuministrosProject.Domain;
using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuministrosProject.AppServices
{
    public class ProductOrderAppServices
    {
        public SuministrosContext db = new SuministrosContext();
        public readonly ProductOrderDomain PO = new ProductOrderDomain();

        public async Task<string> InsertarPO(ProductOrder productOrder)
        {
            var respuestaPODomain = PO.validarPO(productOrder);
            bool ErrorPODomain = respuestaPODomain != null;

            if (ErrorPODomain)
            {
                return respuestaPODomain;
            }
            try
            {
                
                db.ProductOrder.Add(productOrder);
                await db.SaveChangesAsync();
                
            }
            catch (Exception e)
            {
               return e.InnerException.Message;
            }
            return null;
        }
    }
}