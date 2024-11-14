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
    public class DOAPermisoPersona
    {
        public static int GuardarPermiso(EntPermisoPersona obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into PermisoPersona (CrearPersona,CrearUsuario,ModificarUsuario,Deshabilitar," +
                "AgregarDocumentos,ListaPersona,Cod_Usua,Cod_UsuaReg)" +
                "values (@CrearPersona,@CrearUsuario,@ModificarUsuario,@Deshabilitar,@AgregarDocumentos,@ListaPersona,@Cod_Usua,@Cod_UsuaReg);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@CrearPersona", obj.CrearPersona);
                cmd.Parameters.AddWithValue("@CrearUsuario", obj.CrearUsuario);
                cmd.Parameters.AddWithValue("@ModificarUsuario", obj.ModificarUsuario);
                cmd.Parameters.AddWithValue("@Deshabilitar", obj.Deshabilitar);
                cmd.Parameters.AddWithValue("@AgregarDocumentos", obj.AgregarDocumentos);
                cmd.Parameters.AddWithValue("@ListaPersona", obj.ListaPersona);
                cmd.Parameters.AddWithValue("@Cod_Usua", obj.Cod_Usua);
                cmd.Parameters.AddWithValue("@Cod_UsuaReg", obj.Cod_UsuaReg);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                obj = null;
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
        public static void ModificarPermiso(EntPermisoPersona obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "update PermisoPersona set CrearPersona=@CrearPersona,CrearUsuario=@CrearUsuario,ModificarUsuario=@ModificarUsuario,Deshabilitar=@Deshabilitar," +
                "AgregarDocumentos=@AgregaraDocumentos,ListaPersona=@ListaPersona where Cod_UsuaReg=@Cod_UsuaReg;";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@CrearPersona", obj.CrearPersona);
                cmd.Parameters.AddWithValue("@CrearUsuario", obj.CrearUsuario);
                cmd.Parameters.AddWithValue("@ModificarUsuario", obj.ModificarUsuario);
                cmd.Parameters.AddWithValue("@Deshabilitar", obj.Deshabilitar);
                cmd.Parameters.AddWithValue("@AgregarDocumentos", obj.AgregarDocumentos);
                cmd.Parameters.AddWithValue("@ListaPersona", obj.ListaPersona);
                cmd.Parameters.AddWithValue("@Cod_UsuaReg", obj.Cod_UsuaReg);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                obj = null;
                myTrans.Rollback();
                

            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public static EntPermisoPersona BuscarPermiso(int Id)
        {
            EntPermisoPersona obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarPermisoPersona", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntPermisoPersona();
                dr.Read();

                obj.CrearPersona = Convert.ToInt32(dr["CrearPersona"].ToString());
                obj.CrearUsuario = Convert.ToInt32(dr["CrearUsuario"].ToString());
                obj.ModificarUsuario = Convert.ToInt32(dr["ModificarUsuario"].ToString());
                obj.Deshabilitar = Convert.ToInt32(dr["Deshabilitar"].ToString());
                obj.AgregarDocumentos = Convert.ToInt32(dr["AgregarDocumentos"].ToString());
                obj.ListaPersona = Convert.ToInt32(dr["ListaPersona"].ToString());
                obj.Cod_UsuaReg = Convert.ToInt32(dr["Cod_UsuaReg"].ToString());

            }
            catch (Exception e)
            {
                obj.CrearPersona = 0;
                obj.CrearUsuario = 0;
                obj.ModificarUsuario = 0;
                obj.Deshabilitar = 0;
                obj.AgregarDocumentos = 0;
                obj.ListaPersona = 0;
                obj.Cod_UsuaReg = 0;
                return null;
            }
            finally
            {
                cnx.Close();
            }
            return obj;
        }
    }
}