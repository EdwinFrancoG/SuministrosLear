using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SuministrosProject.Models
{
    public class Categoria
    {
        public Categoria()
        {
            NumeroParte = new HashSet<NumeroParte>();
        }

        [Key]
        public int IdCategoria { get; set; }
        public string CategoriaDescripcion { get; set; }
        public string Observacion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<NumeroParte> NumeroParte { get; set; }
    }
}
