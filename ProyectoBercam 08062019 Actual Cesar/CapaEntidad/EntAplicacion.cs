using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntAplicacion
    {
        public int Id { get; set; }
        public string Asegurado { get; set; }
        public string Asegurado_Adicional { get; set; }
        public string Producto_Asegurado { get; set; }
        public double Volumen_Transportado { get; set; }
        public double Valor_Asegurado { get; set; }
        public string NumeroDim { get; set; }
        public string MedioDeTransporte { get; set; }
        public double LimiteMaximoEmbarque { get; set; }
        public string Travesia { get; set; }
        public string FronteraDeIngreso { get; set; }
        public string Coberturas { get; set; }
        public DateTime PeriodoCargaDesde { get; set; }
        public DateTime PeriodoCargaHasta { get; set; }
        public string Deducible { get; set; }
        public double PrimaTotal { get; set; }
        public string FormaDePago { get; set; }
        public int IdDim { get; set; }
        public double PrecioPromedio { get; set; }
    }
}