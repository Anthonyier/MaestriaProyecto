using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalle_Certificados
    {
        public int Id_Detalle { get; set; }
        public int Id_Camion { get; set; }
        public int Id_Certificado { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public byte[] Imagen { get; set; }
        public string Ext { get; set; }
        public string Nombre { get; set; }
        public double DiasVigencia { get; set; }

        public int Estado { get; set; }
        public DateTime Fecha_registro { get; set; }
        public int Aplica { get; set; }
    }
}