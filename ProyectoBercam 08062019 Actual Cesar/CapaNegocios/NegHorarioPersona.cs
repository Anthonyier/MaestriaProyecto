using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaNegocios
{
    public class NegHorarioPersona
    {
        public static void GuardarHorarioPersona(EntHorarioPersona Hp)
        {
            DAOHorarioPersona.GuardarHorarioPersona(Hp);
        }
        public static EntHorarioPersona Repetidos(DateTime fecha,int Id )
        {
            return DAOHorarioPersona.ObtenerHorario(fecha,Id);
        }
    }
}