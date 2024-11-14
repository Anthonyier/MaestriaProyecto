using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntTransaccion
    {
        public int IdTransaccion { get; set; }
        public double Monto { get; set; }
        public double TipoCambio { get; set; }
        public string Glosa { get; set; }
        public int Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdMoneda { get; set; }
        public int IdFormaPago { get; set; }
        public int IdCuenta { get; set; }
        public int IdTipoTransaccion { get; set; }

    }
}