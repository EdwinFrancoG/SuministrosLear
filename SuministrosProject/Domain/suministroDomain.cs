using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuministrosProject.Domain
{
    public class suministroDomain
    {
        public SuministrosContext db = new SuministrosContext();

        public async Task<string> validarSuministro(Suministro suministro)
        {
            bool suministroIsEmpty = suministro == null;
            if (suministroIsEmpty)
            {
                return "Los campos estan vacios";
            }

            //busca la serie del suministro en la tabla suministros para validar si existe
            var buscarSumiistro = db.Suministro.Where(s => s.Serie == suministro.Serie).FirstOrDefault();
            bool suministroExiste = buscarSumiistro != null;
            if (suministroExiste)
            {
                return "Este suministro ya fue creado interiormente, revise que la serie este correctamente";
            }


            //si el input de serie esta vacio nos retorna el rotulo de que ingrese la serie
            bool serieIsEmpty = suministro.Serie == null;
            if (serieIsEmpty)
            {
                return "Ingrese la serie del suministro";
            }

            bool state = true;
            suministro.Estado = state;

            // llamamos a la funcion de sumar en stock.
            int idNumeroParte = Convert.ToInt32(suministro.IdNumeroParte);
            var RespuestaSumaDeStock = await sumarStock(idNumeroParte);

            //verificamos de que no haya erro en la respueta de la funcion y si lo hay que retorne el error
            bool errorAlSumarEnStock = RespuestaSumaDeStock != null;           
            if (errorAlSumarEnStock)
            {
                return RespuestaSumaDeStock;
            }

            return null;
        }


        public async Task<string> sumarStock(int numeroParte)
        {            
            var NumeroParteEnStock = db.Stock.Where(s => s.IdNumeroParte == numeroParte).FirstOrDefault();     

            //verificamos que el numero de parte exista en el stock de no ser asi se crea nuevo.
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
                    newStock.Pendientes = 0;
                    newStock.Total = 1;
                    newStock.Estado = true;

                    //guardamos los cambios
                    db.Stock.Add(newStock);
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    //si algo falla retornamos el error
                    return e.InnerException.Message;
                }

            }
            //si ya existe solo sumamos a las entradas y a la cantidad actual
            else
            {
                try
                {
                    //creacion de variables para hacer los calculos
                    int entradas = Convert.ToInt32(NumeroParteEnStock.Entradas);
                    int pendientes = Convert.ToInt32(NumeroParteEnStock.Pendientes);
                    int cantidadActual = Convert.ToInt32(NumeroParteEnStock.CantidadActual);
                    int stockInicio = Convert.ToInt32(NumeroParteEnStock.StockInicial);
                    int stockSalidas = Convert.ToInt32(NumeroParteEnStock.Salidas);
                    int newEntradas;
                    int cantidadActualUpdate;


                    //calculos para hacer la entrada del sunibistro al stick
                    newEntradas = entradas + 1;
                    cantidadActualUpdate = (stockInicio + newEntradas) - stockSalidas;
                    NumeroParteEnStock.Entradas = newEntradas;
                    NumeroParteEnStock.CantidadActual = cantidadActualUpdate;
                    NumeroParteEnStock.Total = cantidadActualUpdate + pendientes;

                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {

                    return e.InnerException.Message;
                }
            }
            return null;
        }

        public async Task<string> validarEliminacion(int id)
        {
            //variables para busqueda de suministro en listado de suministros y en el stock
            var suministro = db.Suministro.Where(s => s.IdSuministro == id).FirstOrDefault();
            var numeroParteSuministro = suministro.IdNumeroParte;
            var numeroParteEnStock = db.Stock.Where(n => n.IdNumeroParte == numeroParteSuministro).FirstOrDefault();
            try
            {
                //variables de stock para calculos
                int salidas = Convert.ToInt32(numeroParteEnStock.Salidas);
                int cantidadActual = Convert.ToInt32(numeroParteEnStock.CantidadActual);
                int pendientes = Convert.ToInt32(numeroParteEnStock.Pendientes);
                int stockIniscial = Convert.ToInt32(numeroParteEnStock.StockInicial);
                int entradas = Convert.ToInt32(numeroParteEnStock.Entradas);
                int total = Convert.ToInt32(numeroParteEnStock.Total);

                //Si no hay suministros en fisico o mejor dicho no hay cantidad actual, que retorne el siguiente texto
                if (cantidadActual <= 0)
                {
                    return "No hay suministros en stock de este numero de parte";
                }
                else
                {
                    // calculos para dar de baja al suministro en el stock
                    int salidasUpdate; int cantidadActualUpdate; int totalUpdate;

                    salidasUpdate = salidas + 1;
                    cantidadActualUpdate = (stockIniscial + entradas) - salidasUpdate;
                    totalUpdate = cantidadActualUpdate + pendientes;

                    numeroParteEnStock.Salidas = salidasUpdate;
                    numeroParteEnStock.CantidadActual = cantidadActualUpdate;
                    numeroParteEnStock.Total = totalUpdate;

                    await db.SaveChangesAsync();
                    return null;
                }
            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }       
        }
    }
}
