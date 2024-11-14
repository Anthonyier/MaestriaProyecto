using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntHorarioPersona
    {

       public int id { get; set; }
       public DateTime Horario1 { get; set; }
       public DateTime Horario2 { get; set; }
       public DateTime Horario3 { get; set; }
       public DateTime Horario4 { get; set; }
       public double  TotalHora { get; set; }
       public double HorasFaltantes { get; set; }
       public int IdPerZkt { get; set; }

    }
}