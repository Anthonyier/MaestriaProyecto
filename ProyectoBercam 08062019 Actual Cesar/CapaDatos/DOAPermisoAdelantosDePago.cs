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
    public class DOAPermisoAdelantosDePago
    {
        public static int GuardarPermiso(EntPermisosAdelantosDePago Per)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "insert into PermisosAdelantosDePago(PagarAdelantoDePago,Cod_Usuario,Cod_UsuaReg)" +
                "values(@PagarAdelantoDePago,@Cod_Usuario,@Cod_UsuaReg);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@PagarAdelantoDePago", Per.PagarAdelantoDePago);
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

        public static void ModificarPermiso(EntPermisosAdelantosDePago Per)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "update PermisosAdelantosDePago set PagarAdelantoDePago=@PagarAdelantoDePago where Cod_UsuaReg=@Cod_UsuaReg;";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@PagarAdelantoDePago", Per.PagarAdelantoDePago);
                cmd.Parameters.AddWithValue("@Cod_UsuaReg", Per.Cod_UsuaReg);
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

        public static EntPermisosAdelantosDePago BuscarPermiso(int Id)
        {
            EntPermisosAdelantosDePago Per = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cmd = new SqlCommand("BuscarPermisoAdelantosDePago", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                Per = new EntPermisosAdelantosDePago();
                dr.Read();

                Per.PagarAdelantoDePago = Convert.ToInt32(dr["PagarAdelantoDePago"].ToString());
                Per.Cod_UsuaReg = Convert.ToInt32(dr["Cod_UsuaReg"].ToString());
            }
            catch (Exception e)
            {
                Per.PagarAdelantoDePago = 0;
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