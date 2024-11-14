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
    public class DOACuentaPadre
    {
        public static int GuardarCuentaPadre(EntCuentaPadre obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            int Id_CuentaPadre = 0;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into CuentaPadre(CuentaPadre,CuentaHijo)values(@CuentaPadre,@CuentaHijo);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@CuentaPadre", obj.CuentaPadre);
                cmd.Parameters.AddWithValue("@CuentaHijo", obj.CuentaHijo);
                cmd.Transaction = myTrans;
                Id_CuentaPadre = Convert.ToInt32(cmd.ExecuteScalar());
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

        public static int ActualizarCuentaPadre(EntCuentaPadre obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update CuentaPadre set CuentaHijo=@CuentaHijo where CuentaPadre=@CuentaPadre";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@CuentaHijo", obj.CuentaHijo);
                cmd.Parameters.AddWithValue("@CuentaPadre", obj.CuentaPadre);
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