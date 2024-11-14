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
    public class CambiarEstado
    {
        public static int CambioEstado(int est,string id,string obs,int chofer)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                DateTime fecha = DateTime.Today;
                string fechaHoy = fecha.ToString("dd-MM-yyyy");
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                String sql = "Update Camiones set Estado=@Estado,OBS=@OBS,FechaEstado=@FechaEstado where Placa=@Placa";
                cmd = new SqlCommand(sql,cnx);
                cmd.Parameters.AddWithValue("@Estado",est);
                cmd.Parameters.AddWithValue("@OBS",obs);
                cmd.Parameters.AddWithValue("@FechaEstado",fechaHoy);
                cmd.Parameters.AddWithValue("@Placa", id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                sql = "insert into Detalle_Camion(IdEstado,Placa,IdChofer) values(@IdEstado,@Placa,@IdChofer);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql,cnx);
                cmd.Parameters.AddWithValue("@IdEstado",est);
                cmd.Parameters.AddWithValue("@Placa", id);
                cmd.Parameters.AddWithValue("@IdChofer",chofer);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                return 0;
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
            return 1;
        }
    }
}