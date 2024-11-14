using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntFacturaTrans
    {
        public int id { get; set; }
        public string factura { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public int IdConciliacion { get; set; }
        public int IdConciliacionAceite { get; set; }
    }
}