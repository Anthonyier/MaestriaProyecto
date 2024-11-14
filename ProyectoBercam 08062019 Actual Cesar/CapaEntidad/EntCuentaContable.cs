using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntCuentaContable
    {
        public int Id { get; set; }
        public string NumerodeOrden { get; set; }
        public string NombredelaAccion { get; set; }
        public int Id1Nivel { get; set; }
        public int Id2Nivel { get; set; }
        public int Id3Nivel { get; set; }
        public int Id4Nivel { get; set; }
        public int Id5Nivel { get; set; }
        public int Idpadre { get; set; }
    }
}