using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntImagenesAdelantoDePagos
    {
        public int Id { get; set; }
        public byte[] Imagen { get; set; }
        public string Nombre { get; set; }
        public string Ext { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int IdAdelanto { get; set; }

    }
}