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
    public class DAOPermisoAnticipos
    {
        public static int GuardarPermiso(EntPermisoAnticipos Obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into PermisoAnticipos (PagarAnticipo,VerAnticipo,ModAnticipo,EliminarAnticipo," +
                "Cod_Usua,Cod_UsuaReg)" +
                "values (@PagarAnticipo,@VerAnticipo,@ModAnticipo,@EliminarAnticipo,@Cod_Usua,@Cod_UsuaReg);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@PagarAnticipo", Obj.PagarAnticipo);
                cmd.Parameters.AddWithValue("@VerAnticipo", Obj.VerAnticipo);
                cmd.Parameters.AddWithValue("@ModAnticipo", Obj.ModAnticipo);
                cmd.Parameters.AddWithValue("@EliminarAnticipo", Obj.EliminarAnticipo);
                cmd.Parameters.AddWithValue("@Cod_Usua", Obj.Cod_Usua);
                cmd.Parameters.AddWithValue("@Cod_UsuaReg", Obj.Cod_UsuaReg);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Obj = null;
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
        public static EntPermisoAnticipos BuscarPermiso(int Id)
        {
            EntPermisoAnticipos obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarPermisoAnticipos", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                obj = new EntPermisoAnticipos();
                dr = cmd.ExecuteReader();
                dr.Read();
                obj.PagarAnticipo = Convert.ToInt32(dr["PagarAnticipo"].ToString());
                obj.VerAnticipo = Convert.ToInt32(dr["verAnticipo"].ToString());
                obj.ModAnticipo = Convert.ToInt32(dr["ModAnticipo"].ToString());
                obj.EliminarAnticipo = Convert.ToInt32(dr["EliminarAnticipo"].ToString());
              
                obj.Cod_UsuaReg = Convert.ToInt32(dr["Cod_UsuaReg"].ToString());

            }
            catch (Exception e)
            {
                obj.PagarAnticipo = 0;
                obj.VerAnticipo = 0;
                obj.ModAnticipo = 0;
                obj.EliminarAnticipo = 0;
              
                return null;
            }
            finally
            {
                cnx.Close();
            }
            return obj;
        }
        public static void ModificarPermiso(EntPermisoAnticipos  obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "update PermisoAnticipos set PagarAnticipo=@PagarAnticipo,VerAnticipo=@VerAnticipo,ModAnticipo=@ModAnticipo,EliminarAnticipo=@EliminarAnticipo"+ 
                    "where Cod_UsuaReg=@Cod_UsuaReg;";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@PagarAnticipo", obj.PagarAnticipo);
                cmd.Parameters.AddWithValue("@VerAnticipo", obj.VerAnticipo);
                cmd.Parameters.AddWithValue("@ModAnticipo", obj.ModAnticipo);
                cmd.Parameters.AddWithValue("@EliminarAnticipo", obj.EliminarAnticipo);
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
    }
}