using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DAODetalleHorario
    {
        public static bool GuardarDetallehorario( ref SqlConnection cnx ,EntDetalleHorario DetHor)
        {
            SqlCommand cmd = null;
            int IdHor = 0;
            try
            {
                string sql = "Insert into DetalleHorarioPersona (HorasTotal,IdHorarioMañana,IdHorarioTarde,IdPersona) values" +
                    "(@HorasTotal,@IdHorarioMañana,@IdHorarioTarde,@IdPersona);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@HorasTotal", DetHor.HorasTotal);
                cmd.Parameters.AddWithValue("@IdHorarioMañana",DetHor.IdHorarioMañana);
                cmd.Parameters.AddWithValue("@IdHorarioTarde", DetHor.IdHorarioTarde);
                cmd.Parameters.AddWithValue("@IdPersona", DetHor.IdPersona);
             
                IdHor = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                return false;
            }
            return true ;

        }
    }
}