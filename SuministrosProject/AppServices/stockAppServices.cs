using SuministrosProject.Domain;
using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuministrosProject.AppServices
{
    public class stockAppServices
    {
        public SuministrosContext db = new SuministrosContext();
        public readonly stockDomain StockDomain = new stockDomain();

        public stockAppServices()
        {
        }

        public async Task<string> IngresarStock(Stock stock)
        {
            var buscarNumeroParteEnStock = db.Stock.Where(s => s.IdNumeroParte == stock.IdNumeroParte).FirstOrDefault();
            bool numeroParteExiste = buscarNumeroParteEnStock != null;
            if (numeroParteExiste)
            {
                return "This part number is already exist in stock";
            }
            var respuestaStockDomain = StockDomain.validarIngresoStock(stock);
            bool ErrorEnDomain = respuestaStockDomain != null;
            if (ErrorEnDomain)
            {
                return respuestaStockDomain;
            }
            try
            {
                db.Stock.Add(stock);
                await db.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return e.Message;
            }
            return null;
        }

        public async Task<string> eliminarStock(int id)
        {
            var ItemDelete = db.Stock.Where(x => x.IdStock == id).FirstOrDefault();
            int TotalSuministros = Convert.ToInt32(ItemDelete.Total);
            if (TotalSuministros == 0 )
            {
                Stock stock = await db.Stock.FindAsync(id);
                db.Stock.Remove(stock);
                await db.SaveChangesAsync();
                return null;
            }

            return "Error, You still have Supplies in stock for this Item, output to all supplies to be able to eliminate it";
        }

    }
}
