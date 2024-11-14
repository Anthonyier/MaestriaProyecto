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
    public class NegHorarioFaltantes
    {
        public static void GuardarHorariosFaltantes(DateTime fecha,int IdPersona)
        {
            DAOHorarioFaltantes.GuardarHorarioFaltante(fecha, IdPersona);
        }
        public static SqlDataReader ReaderHorarios(DateTime fecha)
        {
           return DAOHorarioFaltantes.BuscarHorarioFaltante(fecha);
        }
    }
}