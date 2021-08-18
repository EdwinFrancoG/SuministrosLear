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
            Stock = new HashSet<Stock>();
        }

        [Key]
        public int idLocalizacion { get; set; }
        public string descripcion { get; set; }

        public virtual ICollection<Stock> Stock { get; set; }
    }
}