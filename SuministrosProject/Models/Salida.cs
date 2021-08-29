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
        public DateTime? FechaSalida { get; set; }
        public int idEquipo { get; set; }

        public virtual Suministro IdSuministroNavigation { get; set; }
        public virtual Equipo IdEquipoNaviation { get; set; }

        //modificar controlador y la clase de contexto
    }
}
