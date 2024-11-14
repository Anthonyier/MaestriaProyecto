using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntPermisoCamiones
    {
        public int Cod_Asig { get; set; }
        public int CrearCamion { get; set; }
        public int ModificarCamiones { get; set; }
        public int DocumentoCamion { get; set; }
        public int ListaCamion { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Cod_Usua { get; set; }
        public int Cod_UsuaReg { get; set; }
    }
}