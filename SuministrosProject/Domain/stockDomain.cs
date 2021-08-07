using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuministrosProject.Domain
{
    public class stockDomain
    {
        public string validarIngresoStock(Stock stock)
        {
            int inicioStock = Convert.ToInt32(stock.StockInicial);
            int entradas = Convert.ToInt32(stock.Entradas);
            int salidas = Convert.ToInt32(stock.Salidas);
            int pendientes = Convert.ToInt32(stock.Pendientes);
            int cantidadActual = Convert.ToInt32(stock.CantidadActual);

            bool isModelEmpty = stock == null;
            if (isModelEmpty)
            {
                return "Los campos estan vacios porfavor ingrese datos correctamente";
            }

            bool stockInicialIsEmpety = stock.StockInicial == null;
            if (stockInicialIsEmpety)
            {
                return "Por Favor ingrese un inicio de stock";
            }

            stock.FechaInicio = DateTime.Now;

            entradas = 0; salidas = 0;
            cantidadActual = (inicioStock + entradas) - salidas;
            stock.Total = cantidadActual + pendientes;

            stock.Entradas = entradas;
            stock.Salidas = salidas;
            stock.Pendientes = pendientes;
            stock.CantidadActual = cantidadActual;
            stock.Estado = true;

            return null;
        }


        public string eliminarStockInvetario(Stock stock)
        {
            bool isModelEmpty = stock == null;
            if (isModelEmpty)
            {
                return "Elemento no encontrado";
            }
            return null;
        }

    }
}