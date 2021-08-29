using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuministrosProject.Models
{
    public class Entrada
    {
        [Key]
        public int IdEntrada { get; set; }
        public string SerieSuministro { get; set; }
        public int IdNumeroParte { get; set; }
        public int IdLocalizacion { get; set; }

        public virtual NumeroParte IdNumeroParteNavigation { get; set; }
        public virtual Localizacion IdLocalizacionNavigation { get; set; }
    }
}