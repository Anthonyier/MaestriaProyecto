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
    public class DAOBanco
    {
        public static int GuardarBanco(EntBanco obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

         

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into Banco(Descripcion)values(@Descripcion);SELECT Scope_Identity();" ;
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Transaction = myTrans;
               cmd.ExecuteNonQuery();
              
            }
            catch(Exception e)
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

        public static int ActualizarBanco(EntBanco obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            try
            {
                ClaseConexion Conexion=new ClaseConexion();
                SqlConnection cnx=Conexion.conectar();
                cnx.Open();
                myTrans=cnx.BeginTransaction();
                string sql= "Update Banco set Descripcion=@Descripcion where Id_Banco=@Id_Banco";
                cmd=new SqlCommand(sql,cnx);
                cmd.Parameters.AddWithValue("@Descripcion",obj.Descripcion);
                cmd.Parameters.AddWithValue("@Id_Banco",obj.Id_Banco);
                cmd.Transaction=myTrans;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e){
                obj=null;
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