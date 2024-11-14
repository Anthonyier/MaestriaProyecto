using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntMaestroProveedor
    {
        public DateTime FechaAntcipo { get; set; }
        public int IdPers { get; set; }
        public int IdUsuario { get; set; }
        public double MontoAnticipo { get; set; }
        public int IdAnticipo { get; set; }
        public int IdTipoPago { get; set; }
    }
}