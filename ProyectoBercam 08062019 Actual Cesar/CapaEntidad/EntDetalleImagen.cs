using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalleImagen
    {
        public int Id_DetalleImg { get; set; }
        public int Id_Imagen { get; set; }
        public Byte[] Imagen { get; set; }
        public DateTime FechaVigencia{get;set;}
        public DateTime FechaRegistro { get; set; }
    }
}