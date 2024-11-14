using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalle_Transportado
    {
        public int Id_Detalle { get; set; }
        public double MontoTotalTransportado { get; set; }

        public int Conciliacion { get; set; }
        public int Producción { get; set; }
    }
}