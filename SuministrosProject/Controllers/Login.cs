using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SuministrosProject.Models
{
    public class Login
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}