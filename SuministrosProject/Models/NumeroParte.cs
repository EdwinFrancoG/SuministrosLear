using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuministrosProject.Models
{
    public partial class NumeroParte
    {
        public NumeroParte()
        {
            Stock = new HashSet<Stock>();
            DetallePo = new HashSet<DetallePo>();
            Suministro = new HashSet<Suministro>();
            Entrada = new HashSet<Entrada>();
        }

        [Key]
        public int IdNumeroParte { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int? IdCategoria { get; set; }
        public string Observacion { get; set; }
        public bool Estado { get; set; }


        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
        public virtual ICollection<DetallePo> DetallePo { get; set; }
        public virtual ICollection<Suministro> Suministro { get; set; }
        public virtual ICollection<Entrada> Entrada { get; set; }
    }
}