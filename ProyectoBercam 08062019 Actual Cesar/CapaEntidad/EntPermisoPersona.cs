using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntPermisoPersona
    {
        public int Cod_Asig { get; set; }
        public int CrearPersona { get; set; }
        public int CrearUsuario { get; set; }
        public int ModificarUsuario { get; set; }
        public int Deshabilitar { get; set; }
        public int AgregarDocumentos { get; set; }
        public int ListaPersona { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Cod_Usua { get; set; }
        public int Cod_UsuaReg { get; set; }
    }
}