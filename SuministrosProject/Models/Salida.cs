using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SuministrosProject.Models
{
    public partial class Salida
    {
        [Key]
        public int IdSalida { get; set; }
        public int? IdSuministro { get; set; }
        public int? Cantidad { get; set; }
        public string Equipo { get; set; }
        public string Observacion { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string IdGafete { get; set; }

        public virtual Usuario IdGafeteNavigation { get; set; }
        public virtual Suministro IdSuministroNavigation { get; set; }
    }
}
