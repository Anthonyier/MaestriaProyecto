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
    public class DAOMarca
    {
           public static int GuardarMarca(EntMarca obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
               ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into Marca(Descripcion)values(@Descripcion);SELECT Scope_Identity();" ;
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
           public static int ActualizarMarca(EntMarca obj)
           {
               SqlCommand cmd = null;
               SqlTransaction myTrans = null;
               try
               {
                   ClaseConexion Conexion=new ClaseConexion();
                   SqlConnection cnx = Conexion.conectar();
                   cnx.Open();
                   myTrans=cnx.BeginTransaction();
                   string sql="Update Marca set Descripcion=@Descripcion where Id_Marca=@Id_Marca";
                   cmd= new SqlCommand(sql,cnx);
                   cmd.Parameters.AddWithValue("@Descripcion",obj.Descripcion);
                   cmd.Parameters.AddWithValue("@Id_Marca",obj.Id_Marca);
                   cmd.Transaction=myTrans;
                   cmd.ExecuteNonQuery();
               }
               catch(Exception e)
               {
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

           public static EntMarca Repetidos(string desc)
           {
               SqlCommand cmd = null;
               SqlDataReader dr = null;
               EntMarca mar = null;
               ClaseConexion cn = new ClaseConexion();
               SqlConnection cnx = cn.conectar();
               try
               {

                   cmd = new SqlCommand("MarcaRepetida", cnx);
                   cmd.Parameters.AddWithValue("@Nombre", desc);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cnx.Open();
                   dr = cmd.ExecuteReader();
                   mar = new EntMarca();
                   dr.Read();
                   mar.Id_Marca = Convert.ToInt32(dr["Id_Marca"].ToString());
                   mar.Descripcion = dr["Descripcion"].ToString();

               }
               catch (Exception e)
               {
                   mar = null;
               }
               finally
               {
                   cnx.Close();
               }

               return mar;
           }
    }
}