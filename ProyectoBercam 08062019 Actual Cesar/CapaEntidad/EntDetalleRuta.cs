using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalleRuta
    {
        public int Id { get; set; }
        public int IdRuta { get; set; }
        public int IdProducto { get; set; }
        public double MermaMaxima { get; set; }
        public double MultaProducto { get; set; }
    }
}