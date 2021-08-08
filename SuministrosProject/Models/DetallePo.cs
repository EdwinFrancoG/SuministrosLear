using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SuministrosProject.Models
{
    public partial class DetallePo
    {
        [Key]
        public int IdDetallePo { get; set; }
        public int? IdProductOrder { get; set; }
        public int? IdSuministro { get; set; }
        public int? cantidadPedido { get; set; }
        public int? CantidadRecibida { get; set; }
        public bool? Pendiente { get; set; }
        public int? CantidadPendiente { get; set; }
        public string Observacion { get; set; }

        public virtual ProductOrder IdProductOrderNavigation { get; set; }
        public virtual Suministro IdSuministroNavigation { get; set; }
    }
}
