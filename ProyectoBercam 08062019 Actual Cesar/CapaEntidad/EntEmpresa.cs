using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntEmpresa
    {
        public int Id_Empresa { get; set; }
        public int NIT { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TelfRefrencia { get; set; }
        public string Email { get; set; }
        public int Id_PersonaContacto { get; set; }
        public int Cod_Ente { get; set; }

    }
}