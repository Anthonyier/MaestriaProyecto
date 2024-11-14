using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDatosEmpresa
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public int Nit { get; set; }
        public string Rubro { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string NombreContacto { get; set; }
        public string Email { get; set; }
        public string EmailEnvio { get; set; }
        public string PaginaWeb { get; set; }
        public string Facebook { get; set; }
        public string Whatsapp { get; set; }
        public int Cod_Ente { get; set; }

    }
}