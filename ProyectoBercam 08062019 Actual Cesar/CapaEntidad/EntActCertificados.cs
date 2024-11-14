using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntActCertificados
    {
        public int Id_Cert { get; set; }
        public DateTime F_RegistroAct { get; set; }
        public DateTime FVenc { get; set; }
        public int Id_Camion { get; set; }
    }
}