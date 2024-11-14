using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntProveedores
    {
        public int Id_Proveedores { get; set; }
        public string CI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TelfReferencia { get; set; }
        public string Email { get; set; }
        public string Emision { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Cod_Ente { get; set; }
    }
}