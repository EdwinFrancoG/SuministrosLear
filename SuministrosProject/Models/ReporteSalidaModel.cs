using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuministrosProject.Models
{
    public class ReporteSalidaModel
    {
        public string serieSuministro { get; set; }
        public string numeroParte { get; set; }
        public string fechaSalida { get; set; }
        public string equipo { get; set; }
    }
}