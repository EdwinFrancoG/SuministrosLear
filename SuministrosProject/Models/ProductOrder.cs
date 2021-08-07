using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SuministrosProject.Models
{
    public class ProductOrder
    {
        public ProductOrder()
        {
            DetallePo = new HashSet<DetallePo>();
        }

        [Key]
        public int IdProductOrder { get; set; }
        public string Codigo { get; set; }
        public string Requisicion { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public string IdGafete { get; set; }
        public string Estado { get; set; }

        public virtual Usuario IdGafeteNavigation { get; set; }
        public virtual ICollection<DetallePo> DetallePo { get; set; }
    }
}
