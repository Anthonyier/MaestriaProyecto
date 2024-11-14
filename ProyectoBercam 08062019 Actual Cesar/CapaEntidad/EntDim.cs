using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDim
    {
        public int Id { get; set; }
        public string Dim { get; set; }
        public string Producto { get; set; }
        public string Proveedor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string AduanaFrontera { get; set; }
        public int Activo { get; set; }
        public int EstCerrado { get; set; }
    }
}