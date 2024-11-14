using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalleDim
    {
        public int Id { get; set; }
        public DateTime FechaPRM { get; set; }
        public string PRMno { get; set; }
        public double VolumenPRM { get; set; }
        public double PesoPRM { get; set; }
        public int IdDim { get; set; }
        public int IdDetalle { get; set; }
    }
}