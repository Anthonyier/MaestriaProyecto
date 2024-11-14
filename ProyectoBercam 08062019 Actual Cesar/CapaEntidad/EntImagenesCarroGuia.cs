using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntImagenesCarroGuia
    {
        public int Id { get; set; }
        public byte[] Imagen { get; set; }
        public string NombreDoc { get; set; }
        public string Ext { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public DateTime FechaPago { get; set; }
        public int IdConciliacionCarroGuia { get; set; }
    }
}