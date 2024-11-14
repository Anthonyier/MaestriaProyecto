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
    public class DAOHorarioFaltantes
    {
        public static void GuardarHorarioFaltante(DateTime Fecha,int IdPersonaZkTeko)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string Sql = "Insert into HorarioFaltantes(Fecha,IdPersonaZkTeko)values(@Fecha,@IdPersonaZkTeko);";
                cmd = new SqlCommand(Sql, cnx);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@IdPersonaZkteko", IdPersonaZkTeko);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                cnx.Close();

            }
            catch (Exception e)
            {
                myTrans.Rollback();
                cnx.Close();
            }
        }

        public static SqlDataReader BuscarHorarioFaltante(DateTime Fecha)
        {
            //EntCamiones obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcHorarioFaltante", cnx);
                cmd.Parameters.AddWithValue("@Fecha",Fecha);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
            
                return dr;
            }
            catch (Exception e)
            {
                //obj = null;
                dr = null;
                return dr;
            }
            finally
            {

            }
        }
    }
}