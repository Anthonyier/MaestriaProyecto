using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntConciliacionPorCobrar
    {
        public string Cliente { get; set; }
        public int Recepcion { get; set; }
        public string recepcionManual { get; set; }
        public string Ruta { get; set; }
        public string Producto { get; set; }
    }
}