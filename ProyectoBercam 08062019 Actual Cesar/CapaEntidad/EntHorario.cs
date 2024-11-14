using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntHorario
    {
        public int Id { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
        public string TotalHoras { get; set; }
        public int IdTipoHorario { get; set; }
    }
}