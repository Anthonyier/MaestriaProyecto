using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntPermisosServicios
    {
        public int Cod_Asig { get; set; }
        public int GuardarTelefono { get; set; }
        public int ModificarTelefono { get; set; }
        public int EliminarTelefono { get; set; }
        public int GuardarRastreo { get; set; }
        public int ModificarRastreo { get; set; }
        public int EliminarRastreo { get; set; }
        public int Cod_Usuario { get; set; }
        public int Cod_UsuaReg { get; set; }

    }
}