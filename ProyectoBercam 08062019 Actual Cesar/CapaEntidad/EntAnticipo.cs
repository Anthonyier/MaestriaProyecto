using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntAnticipo
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public Double Monto { get; set; }
        public int Periodo { get; set; }
        public int IdCamion { get; set; }
        public int Año { get; set; }
        public int Region { get; set; }
        public int Recp { get; set; }
        public int Derecp { get; set; }
        public int Estado { get; set; }
        public int Enviado { get; set; }

    }
}