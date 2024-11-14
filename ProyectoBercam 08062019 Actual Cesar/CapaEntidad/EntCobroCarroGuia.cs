using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntCobroCarroGuia
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public string Placa { get; set; }
        public DateTime fecha { get; set; }
        public int IdCarroGuia { get;set;}
    }
}