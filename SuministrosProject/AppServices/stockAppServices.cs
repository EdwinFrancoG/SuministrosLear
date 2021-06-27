﻿using SuministrosProject.Domain;
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
            var buscarItem = db.Stock.Where(x => x.IdSuministro == stock.IdSuministro).FirstOrDefault();
            if (buscarItem != null)
            {
                return "El Suministro ya esta en existencia, cree una P.O para aumentar la cantidad de este.";
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

            return "Error, Aun tiene Suministros en existencia de este Item, de salida a todos los suministros para poder eliminarlo";
        }

    }
}