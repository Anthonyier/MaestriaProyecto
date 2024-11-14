using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntSoat
    {
        public int IdSoat { get; set; }
        public byte[] ImgSoat { get; set; }
        public DateTime F_Venc { get; set; }
        public string DocumentNombre { get; set; }
        public string Ext { get; set; }
        public double DiasVigencia { get; set; }
        public int Id_Camion { get; set; }
    }
}