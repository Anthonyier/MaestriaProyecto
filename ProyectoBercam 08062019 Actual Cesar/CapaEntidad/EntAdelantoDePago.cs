using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntAdelantoDePago
    {
        public int id { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaAdelanto { get; set; }
        public DateTime FechaPago { get; set; }
        public int IdConciliacion { get; set; }


    }
}