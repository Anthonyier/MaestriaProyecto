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
    public class DOATipo_Ente
    {
        public static int GuardarTipo_Ente(EntTipoEnte obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            int Id_Tipo = 0;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into Tipo_Ente(Descripcion)values(@Descripcion);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Transaction = myTrans;
                Id_Tipo = Convert.ToInt32(cmd.ExecuteScalar());
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

        public static int ActualizarTipo_Ente(EntTipoEnte obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Tipo_Ente set Descripcion=@Descripcion where Id_Tipo=@Id_Tipo";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("@Id_Tipo", obj.Id_Tipo);
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
    }
}