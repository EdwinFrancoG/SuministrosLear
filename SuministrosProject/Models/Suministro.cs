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
            Salida = new HashSet<Salida>();
        }

        [Key]
        public int IdSuministro { get; set; }
        public string Serie { get; set; }
        public int? IdNumeroParte { get; set; }
        public bool? Estado { get; set; }

        public virtual NumeroParte IdNumeroParteNavigation { get; set; }
        public virtual ICollection<Salida> Salida { get; set; }
    }
}
