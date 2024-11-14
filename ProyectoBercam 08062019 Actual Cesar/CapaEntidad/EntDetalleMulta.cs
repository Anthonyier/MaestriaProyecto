using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalleMulta
    {
        public int Id { get; set; }
        public double Precio { get; set; }
        public DateTime Fecharegistro { get; set; }
        public int IdCamion { get; set; }
        public int IdMulta { get; set; }
        public int IdPeriodo { get; set; }
        public int IdAño { get; set; }
        public int IdRegion { get; set; }


    }
}