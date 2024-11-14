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
    public class DOAPermisoCamiones
    {
        public static int GuardarPermiso(EntPermisoCamiones obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into PermisoCamiones (CrearCamion,ModificarCamiones,DocumentosDeCamion,ListaCamion,Cod_Usua,Cod_UsuaReg)" +
                "values (@CrearCamion,@ModificarCamiones,@DocumentosDeCamion,@ListaCamion,@Cod_Usua,@Cod_UsuaReg);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@CrearCamion", obj.CrearCamion);
                cmd.Parameters.AddWithValue("@ModificarCamiones", obj.ModificarCamiones);
                cmd.Parameters.AddWithValue("@DocumentosDeCamion", obj.DocumentoCamion);
                cmd.Parameters.AddWithValue("@ListaCamion", obj.ListaCamion);
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

        public static EntPermisoCamiones BuscarPermiso(int Id)
        {
            EntPermisoCamiones obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarPermisoCamiones", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntPermisoCamiones();
                dr.Read();

                obj.CrearCamion = Convert.ToInt32(dr["CrearCamion"].ToString());
                obj.ModificarCamiones = Convert.ToInt32(dr["ModificarCamiones"].ToString());
                obj.DocumentoCamion = Convert.ToInt32(dr["DocumentosDeCamion"].ToString());
                obj.ListaCamion = Convert.ToInt32(dr["ListaCamion"].ToString());
                obj.Cod_UsuaReg = Convert.ToInt32(dr["Cod_UsuaReg"].ToString());

            }
            catch (Exception e)
            {
                obj.CrearCamion = 0;
                obj.ModificarCamiones = 0;
                obj.DocumentoCamion = 0;
                obj.ListaCamion = 0;
                obj.Cod_UsuaReg = 0;
            }
            finally
            {
                cnx.Close();
            }
            return obj;
        }
    }
}