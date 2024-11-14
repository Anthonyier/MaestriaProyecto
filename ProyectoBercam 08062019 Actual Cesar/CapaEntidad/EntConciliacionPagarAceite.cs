using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntConciliacionPagarAceite
    {
        public int id { get; set; }
        public double FleteBruto { get; set; }
        public double MultaMerma { get; set; }
        public double Anticipos { get; set; }
        public double Servicios { get; set; }
        public double TotalPagable { get; set; }
        public double TotalFactura { get; set; }
        public double TotalAdelantos { get; set; }
        public double PorPagar { get; set; }
        public int IdTitular { get; set; }
        public int IdAño { get; set; }
        public int IdMes { get; set; }
        public int IdFactura { get; set; }
    }
}