using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuministrosProject.Models
{
    public class Equipo
    {
        public Equipo()
        {
            Salida = new HashSet<Salida>();
        }

        [Key]
        public int idEquipo { get; set; }
        public string equipo { get; set; }

        public virtual ICollection<Salida> Salida { get; set; }
    }
}