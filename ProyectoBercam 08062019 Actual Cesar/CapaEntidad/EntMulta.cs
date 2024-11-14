using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntMulta
    {

       public int id {get;set;}
       public string Concepto { get; set; }
       public double Multa { get; set; }
       public int Estado { get; set; }
       public int IdCliente { get; set; }
    }
}