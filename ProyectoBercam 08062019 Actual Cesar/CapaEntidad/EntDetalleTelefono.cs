using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalleTelefono
    {
        public int Id { get; set; }
        public double MontoPagar { get; set; }
        public double MontoCobrar { get; set; }
        public string Numero { get; set; }
        public int Libre { get; set; }
        public string Personal { get; set; }
        public double Credito { get; set; }
        public int Estado { get; set; }
        public int IdCamion { get; set; }
        public int IdAño { get; set; }
        public int IdMes { get; set; }

    }
}