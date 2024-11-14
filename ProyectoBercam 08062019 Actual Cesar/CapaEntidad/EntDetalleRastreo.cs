using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalleRastreo
    {
        public int Id { get; set; }
        public double MontoPagar { get; set; }
        public double MontoCobrar { get; set; }
        public double MontoCinabar { get; set; }
        public int Estado { get; set; }
        public int IdCamion { get; set; }
        public int IdAño { get; set; }
        public int IdMes { get; set; }
        public int IdRastreo { get; set; }
    }
}