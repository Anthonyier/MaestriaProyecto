using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntCamionGuia
    {
        public int Id_Guia { get; set; }
        public double Monto { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha { get; set; }
        public int Año { get; set; }
        public int Id_Proveedor { get; set; }
        public int Periodo { get; set; }
        public int IdRegion { get; set; }
    }
}