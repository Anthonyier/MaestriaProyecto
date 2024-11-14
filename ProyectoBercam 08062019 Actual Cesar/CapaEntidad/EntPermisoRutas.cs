using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntPermisoRutas
    {
        public int Cod_Asig { get; set; }
        public int CrearRuta { get; set; }
        public int ModificarRutas { get; set; }
        public int ProgramaRutas { get; set; }
        public int ListaProgram { get; set; }
        public int ModificarProgramacion { get; set; }
        public int ListaRutas { get; set; }
        public int AnularRutas { get; set; }
        public int ConciliacionCobrar { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Cod_Usua { get; set; }
        public int Cod_UsuaReg { get; set; }
        public int ConfirmarRuta { get; set; }
        public int NoDespachado { get; set; }
        public int Aplicacion { get; set; }
        public int Dim { get; set; }
        public int ConfDescarga { get; set; }
    }
}