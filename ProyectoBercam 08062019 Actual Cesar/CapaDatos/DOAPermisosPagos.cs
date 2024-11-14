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
    public class DOAPermisosPagos
    {
        public static int GuardarPermiso(EntPermisosPagos Per)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "insert into PermisosPagos(ImagenesPagadas,ImagenesPagadasAceite,Cod_Usuario,Cod_UsuaReg)" +
                "values(@ImagenesPagadas,@ImagenesPagadasAceite,@Cod_Usuario,@Cod_UsuaReg);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@ImagenesPagadas", Per.ImagenesPagadas);
                cmd.Parameters.AddWithValue("@ImagenesPagadasAceite", Per.ImagenesPagadasAceite);
                cmd.Parameters.AddWithValue("@Cod_Usuario", Per.Cod_Usuario);
                cmd.Parameters.AddWithValue("@Cod_UsuaReg", Per.Cod_UsuaReg);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Per = null;
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

        public static void ModificarPermiso(EntPermisosPagos Per)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "update PermisosPagos set ImagenesPagadas=@ImagenesPagadas,ImagenesPagadasAceite=@ImagenesPagadasAceite where Cod_UsuaReg=@Cod_UsuaReg;";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@ImagenesPagadas", Per.ImagenesPagadas);
                cmd.Parameters.AddWithValue("@ImagenesPagadasAceite", Per.ImagenesPagadasAceite);
                cmd.Parameters.AddWithValue("@Cod_UsuaReg",Per.Cod_UsuaReg);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Per = null;
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }

        public static EntPermisosPagos BuscarPermiso(int Id)
        {
            EntPermisosPagos Per=null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cmd = new SqlCommand("BuscarPermisoPagados", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                Per = new EntPermisosPagos();
                dr.Read();

                Per.ImagenesPagadas = Convert.ToInt32(dr["ImagenesPagadas"].ToString());
                Per.ImagenesPagadasAceite = Convert.ToInt32(dr["ImagenesPagadasAceite"].ToString());
                Per.Cod_UsuaReg = Convert.ToInt32(dr["Cod_UsuaReg"].ToString());
            }
            catch (Exception e)
            {
                Per.ImagenesPagadas = 0;
                Per.ImagenesPagadasAceite = 0;
                Per.Cod_UsuaReg = 0;
                return null;
            }
            finally
            {
                cnx.Close();
            }
            return Per;
        }
    }
}