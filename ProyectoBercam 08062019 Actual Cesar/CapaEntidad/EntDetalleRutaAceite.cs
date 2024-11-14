using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalleRutaAceite
    {
        public int Id { get; set; }
        public double PrecioTotal {get;set;}
        public double PrecioFletero { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdRuta { get; set; }

    }
}