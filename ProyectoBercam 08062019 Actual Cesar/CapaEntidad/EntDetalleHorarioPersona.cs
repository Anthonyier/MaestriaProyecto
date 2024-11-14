using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalleHorarioPersona
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HorasTotal { get; set; }
        public int IdHorarioEntrada{get;set;}
        public int IdHorarioSalida { get; set; }
        public int IdPersona { get; set; }

    }
}