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
    public class DOAEmpresa
    {
        public static int GuardarEmpresa(EntEmpresa obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            int Id_Empresa = 0;
            int Id_PersonaContacto = 0;
            int Cod_Ente = 0;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into Empresa(NIT,RazonSocial,Direccion,Telefono,TelReferencia,Email,Id_PersonaContacto,Cod_Ente)"
                    + "values(@NIT,@RazonSocial,@Direccion,@Telefono,@TelfReferencia,@Email,@Id_PersonaContacto,@Cod_Ente);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@NIT", obj.NIT);
                cmd.Parameters.AddWithValue("@RazonSocial", obj.RazonSocial);
                cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("@TelfReferencia", obj.TelfRefrencia);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Id_PersonaContacto", obj.Id_PersonaContacto);
                cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                cmd.Transaction = myTrans;
                Id_Empresa = Convert.ToInt32(cmd.ExecuteScalar());
                Id_PersonaContacto = Convert.ToInt32(cmd.ExecuteScalar());
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

        public static int ActualizarEmpresa(EntEmpresa obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Empresa set NIT=@NIT,RazonSocial=@RazonSocial,Direccion=@Direccion,Telefono=@Telefono"+
              ",TelfReferencia=@TelfReferncia,Email=@Email,Id_PersonaContacto=@Id_PersonaContacto,Cod_Ente=@Cod_Ente where Id_Empresa=@Id_Empresa";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@NIT", obj.NIT);
                cmd.Parameters.AddWithValue("@RazonSocial", obj.RazonSocial);
                cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("@TelfReferencia", obj.TelfRefrencia);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Id_PersonaContacto", obj.Id_PersonaContacto);
                cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                cmd.Parameters.AddWithValue("@Id_Empresa", obj.Id_Empresa);
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