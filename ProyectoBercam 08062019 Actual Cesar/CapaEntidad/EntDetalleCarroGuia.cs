using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalleCarroGuia
    {
        public int id { get; set; }
        public double Monto { get; set; }
        public int IdPersona { get; set; }
        public int IdPeriodo { get; set; }
        public int IdAño { get; set; }
        public int IdRegion { get; set; }
        public int Solicitud { get; set; }

    }
}