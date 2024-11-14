using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalleConciliacionPorCobrar
    {
        public int Nro { get; set; }
        public string Conductor { get; set; }
        public string Placa { get; set; }
        public string PlantaOrigen { get; set; }
        public DateTime FechaCarga { get; set; }
        public double Volumen { get; set; }
        public string CreCarga { get; set; }
        public string PlantaDestino { get; set; }
        public DateTime FechaDescarga { get; set; }
        public double VolumenRecibido { get; set; }
        public string CreDescarga { get; set; }
        public double MermaLts { get; set; }
        public double ExcedentePermisible { get; set; }
        public double MontoMultaBs { get; set; }
        public double VolumenFacturar { get; set; }
        public double MontoTotalFactura { get; set; }
        public string HojaRuta { get; set; }
    }
}