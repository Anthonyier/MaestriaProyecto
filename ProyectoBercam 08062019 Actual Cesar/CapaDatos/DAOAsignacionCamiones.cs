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
    public class DAOAsignacionCamiones
    {
        public static int GuardarAsignacion(EntAsignacionCamion Asig)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into AsignacionCamion(IdCamion,IdCliente) values" +
                    "(@IdCamion,@IdCliente);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@IdCamion", Asig.IdCamion);
                cmd.Parameters.AddWithValue("@IdCliente", Asig.IdCliente);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();

            }
            myTrans.Commit();
            cnx.Close();
            return 1;
        }

        public static SqlDataReader Cantidad(int Est, string Cli)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("CantHabCami", cnx);
                cmd.Parameters.AddWithValue("@Est", Est);
                cmd.Parameters.AddWithValue("@Cli", Cli);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception e)
            {
                dr = null;
                return dr;
            }
        }
        public static void EliminarAsignacion(int Id)
        {

            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();

                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "delete from AsignacionCamion where Id=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                //hasta aqui
            }
            catch (Exception e)
            {

                myTrans.Rollback();


            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
    }
}