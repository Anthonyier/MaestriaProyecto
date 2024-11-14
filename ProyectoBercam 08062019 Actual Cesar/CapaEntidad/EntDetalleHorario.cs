using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalleHorario
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string HorasTotal { get; set; }
        public int IdHorarioMañana { get; set; }
        public int IdHorarioTarde { get; set; }
        public int IdPersona { get; set; }
    }
}