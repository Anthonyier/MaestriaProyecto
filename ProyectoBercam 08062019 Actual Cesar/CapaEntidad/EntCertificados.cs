using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntCertificados
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Periodo_vigencia { get; set; }
        public int Estado { get; set; }

        public DateTime FechaRegistro { get; set; }
        
    }
}