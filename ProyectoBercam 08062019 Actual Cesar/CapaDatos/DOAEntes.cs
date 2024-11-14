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
    public class DOAEntes
    {
        public static int GuardarEntes(EntEntes obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            int Cod_Ente= 0;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into Entes(Id_Tipo)values(@Id_Tipo);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id_Tipo", obj.Id_Tipo);
                cmd.Transaction = myTrans;
                Cod_Ente = Convert.ToInt32(cmd.ExecuteScalar());
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

        public static int ActualizarEntes(EntEntes obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Entes set Id_Tipo=@Id_Tipo where Cod_Ente=@Cod_Ente";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id_Tipo", obj.Id_Tipo);
                cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
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