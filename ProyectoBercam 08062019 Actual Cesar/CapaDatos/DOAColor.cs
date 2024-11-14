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
    public class DOAColor
    {
        public static int GuardarColor(EntColor obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

         

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into Color(Descripcion)values(@Descripcion);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
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
        public static int ActualizarColor(EntColor obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Color set Descripcion=@Descripcion where Id_Color=@Id_Color";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Id_Color", obj.Id_Color);
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

        public static EntColor ColorRepetidos(string color)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntColor obj = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("ColorRepetido", cnx);
                cmd.Parameters.AddWithValue("@Color", color);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntColor();
                dr.Read();
                obj.Id_Color = Convert.ToInt32(dr["Id_Color"].ToString());
                obj.Descripcion = dr["Descripcion"].ToString();

            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                cnx.Close();
            }

            return obj;
        }
    }
}