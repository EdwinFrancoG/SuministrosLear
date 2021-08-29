using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SuministrosProject.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            ProductOrder = new HashSet<ProductOrder>();
        }

        [Key]
        public string IdGafete { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        public bool? Estado { get; set; }
        public int? IdPerfil { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
    }
}
