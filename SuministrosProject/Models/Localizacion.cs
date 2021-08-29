using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuministrosProject.Models
{
    public partial class Localizacion
    {
        public Localizacion()
        {
            Entrada = new HashSet<Entrada>();
            Suministro = new HashSet<Suministro>();
        }

        [Key]
        public int idLocalizacion { get; set; }
        public string descripcion { get; set; }

        public virtual ICollection<Entrada> Entrada { get; set; }
        public virtual ICollection<Suministro> Suministro { get; set; }
    }
}