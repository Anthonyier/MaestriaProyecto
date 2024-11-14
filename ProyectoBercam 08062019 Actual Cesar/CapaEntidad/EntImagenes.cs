using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntImagenes
    {
        public int Id_Imagen { get; set; }
        public int Cod_Ente { get; set; }
        public byte[] Imagen { get; set; }
        public DateTime Vigencia { get; set; }
        public byte Estado { get; set; }
        public string Ext { get; set; }
        public string Nombre { get; set; }
        public int Id_Persona { get; set; }
        public int Tipo_Imagen { get; set; }
        public int Aplica { get; set; }
    }
}