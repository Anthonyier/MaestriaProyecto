using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntPermisosConciliaciones
    {
        public int Cod_Asig { get; set; }
        public int ListCobrRef {get;set;}
        public int ListCobrCorp { get; set; }
        public int ListCobrAlc { get; set; }
        public int ListCobrAceite { get; set; }
        public int ListPagarRef { get; set; }
        public int ListPagarCorp { get; set; }
        public int ListPagarAlc { get; set; }
        public int ListPagarAcei { get; set; }
        public int AsegRef { get; set; }
        public int AsegCorp { get; set; }
        public int AsegAlc { get; set; }
        public int AsegAceite{ get; set;}
        public int Cod_Usua { get; set; }
        public int Cod_UsuaReg { get; set; }
        public int AprobCobrRef { get; set; }
        public int AprobCobrCorp { get; set; }
        public int AprobCobrAlc { get; set; }
        public int AprobCobrAcei { get; set; }
    }
}