using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntServicios
    {
        public int id { get; set; }
        public double Monto { get; set; }
        public string Descripcion { get; set; }
        public int IdCamion { get; set; }
        public int IdPeriodo { get; set; }
        public int IdAño { get; set; }
        public int IdRegion { get; set;}
    }
}