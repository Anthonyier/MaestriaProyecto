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
    public class DOAPermisosServicios
    {
        public static int GuardarPermisos(EntPermisosServicios Per)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "insert into PermisosServicios(GuardarTelefono,ModificarTelefono,EliminarTelefono,GuardarRastreo,ModificarRastreo,EliminarRastreo,Cod_Usuario,Cod_UsuaReg)" +
                "values(@GuardarTelefono,@ModificarTelefono,@EliminarTelefono,@GuardarRastreo,@ModificarRastreo,@EliminarRastreo,@Cod_Usuario,@Cod_UsuaReg);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@GuardarTelefono", Per.GuardarTelefono);
                cmd.Parameters.AddWithValue("@ModificarTelefono", Per.ModificarTelefono);
                cmd.Parameters.AddWithValue("@EliminarTelefono",Per.EliminarTelefono);
                cmd.Parameters.AddWithValue("@GuardarRastreo",Per.GuardarRastreo);
                cmd.Parameters.AddWithValue("@ModificarRastreo", Per.ModificarRastreo);
                cmd.Parameters.AddWithValue("@EliminarRastreo", Per.EliminarRastreo);
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
        public static void ModificarPermiso(EntPermisosServicios Per)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "update PermisosServicios set GuardarTelefono=@GuardarTelefono,ModificarTelefono=@ModificarTelefono,"+
                "EliminarTelefono=@EliminarTelefono,GuardarRastreo=@GuardarRastreo,ModificarRastreo=@ModificarRastreo,EliminarRastreo=@EliminarRastreo where Cod_UsuaReg=@Cod_UsuaReg;";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@GuardarTelefono", Per.GuardarTelefono);
                cmd.Parameters.AddWithValue("@ModificarTelefono", Per.ModificarTelefono);
                cmd.Parameters.AddWithValue("@EliminarTelefono", Per.EliminarTelefono);
                cmd.Parameters.AddWithValue("@GuardarRastreo", Per.GuardarRastreo);
                cmd.Parameters.AddWithValue("@ModificarRastreo", Per.ModificarRastreo);
                cmd.Parameters.AddWithValue("@EliminarRastreo", Per.EliminarRastreo);
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
        public static EntPermisosServicios BuscarPermiso(int id)
        {
            EntPermisosServicios Per = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cmd = new SqlCommand("BuscarPermisoServicios", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                Per = new EntPermisosServicios();
                dr.Read();

                Per.GuardarRastreo = Convert.ToInt32(dr["GuardarRastreo"].ToString());
                Per.ModificarRastreo = Convert.ToInt32(dr["ModificarRastreo"].ToString());
                Per.EliminarRastreo = Convert.ToInt32(dr["EliminarRastreo"].ToString());
                Per.GuardarTelefono = Convert.ToInt32(dr["GuardarTelefono"].ToString());
                Per.ModificarTelefono = Convert.ToInt32(dr["ModificarTelefono"].ToString());
                Per.EliminarTelefono = Convert.ToInt32(dr["EliminarTelefono"].ToString());
            }
            catch (Exception e)
            {
                Per.GuardarRastreo = 0;
                Per.ModificarRastreo = 0;
                Per.EliminarRastreo = 0;
                Per.GuardarTelefono = 0;
                Per.ModificarTelefono = 0;
                Per.EliminarTelefono = 0;
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