using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalleCobroCarroGuia
    {
        public int Id { get; set; }
        public int IdCobro { get; set; }
        public int IdCamion { get; set; }
        public int IdProducto { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
    }
}