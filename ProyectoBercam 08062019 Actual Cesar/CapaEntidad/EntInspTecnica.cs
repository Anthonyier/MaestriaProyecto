using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntInspTecnica
    {
        public int Id_Int { get; set; }
        public byte[] ImgIT { get; set; }
        public DateTime F_Venc { get; set; }
        public string DocumentNombre { get; set; }
        public string Ext { get; set; }
        public int Id_Camion { get; set; }
        public double DiasVigencia { get; set; }
    }
    
}