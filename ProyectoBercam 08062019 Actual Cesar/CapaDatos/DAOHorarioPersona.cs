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
    public class DAOHorarioPersona
    {
        public static void GuardarHorarioPersona(EntHorarioPersona HorPer)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into HorariosPersona(Horario1,Horario2,Horario3,Horario4,TotalHoras,IdPerZkt,HorasFaltantes) values" +
                    "(@Horario1,@Horario2,@Horario3,@Horario4,@TotalHoras,@IdPerZkt,@HorasFaltantes);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Horario1", HorPer.Horario1);
                cmd.Parameters.AddWithValue("@Horario2", HorPer.Horario2);
                cmd.Parameters.AddWithValue("@Horario3", HorPer.Horario3);
                cmd.Parameters.AddWithValue("@Horario4", HorPer.Horario4);
                cmd.Parameters.AddWithValue("@TotalHoras",HorPer.TotalHora);
                cmd.Parameters.AddWithValue("@IdPerZkt", HorPer.IdPerZkt);
                cmd.Parameters.AddWithValue("@HorasFaltantes", HorPer.HorasFaltantes);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                cnx.Close();
            }
            myTrans.Commit();
            cnx.Close();
        }
        public static EntHorarioPersona ObtenerHorario(DateTime fecha,int Id)
        {
             SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntHorarioPersona rep = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("RepetidoHorario", cnx);
                cmd.Parameters.AddWithValue("@Fecha", fecha);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                rep = new EntHorarioPersona();
                dr.Read();
                rep.Horario1 = Convert.ToDateTime(dr["Horario1"].ToString());
                rep.Horario2 = Convert.ToDateTime(dr["Horario2"].ToString());

            }
            catch (Exception e)
            {
                rep = null;
            }
            finally
            {
                cnx.Close();
            }

            return rep;
        }
    }
}