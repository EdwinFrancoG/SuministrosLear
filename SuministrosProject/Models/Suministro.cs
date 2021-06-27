using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SuministrosProject.Models
{
    public partial class Suministro
    {
        public Suministro()
        {
            DetallePo = new HashSet<DetallePo>();
            Salida = new HashSet<Salida>();
            Stock = new HashSet<Stock>();
        }

        [Key]
        public int IdSuministro { get; set; }
        public string Serie { get; set; }
        public string Modelo { get; set; }
        public string NumeroParte { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public int? IdCategoria { get; set; }
        public bool? Estado { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<DetallePo> DetallePo { get; set; }
        public virtual ICollection<Salida> Salida { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
