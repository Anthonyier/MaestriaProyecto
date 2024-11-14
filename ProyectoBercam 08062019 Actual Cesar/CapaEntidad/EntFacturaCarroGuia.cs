using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntFacturaCarroGuia
    {
        public int id { get; set; }
        public string factura { get; set; }
        public string Descripcion {get;set;}
        public double Monto { get; set; }
        public int IdConciliacion { get; set; } 

    }
}