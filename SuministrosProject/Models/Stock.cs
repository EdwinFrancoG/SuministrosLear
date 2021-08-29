using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SuministrosProject.Models
{
    public class Stock
    {
        [Key]
        public int IdStock { get; set; }
        public int? IdNumeroParte { get; set; }
        public int? StockInicial { get; set; }
        public DateTime? FechaInicio { get; set; }
        public int? Entradas { get; set; }
        public int? Salidas { get; set; }
        public int? CantidadActual { get; set; }
        public int? Pendientes { get; set; }
        public int? Total { get; set; }
        public bool? Estado { get; set; }

        public virtual NumeroParte IdNumeroParteNavigation { get; set; }
    }
}
