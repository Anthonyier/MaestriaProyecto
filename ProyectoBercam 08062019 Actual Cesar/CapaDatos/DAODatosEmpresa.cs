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
    public class DAODatosEmpresa
    {
        public static int GuardarDatosEmpresa(EntDatosEmpresa obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into DatosEmpresa(Nombre,RazonSocial,Nit,Rubro,Telefono,Direccion,NombreContacto,Email,EmailEnvio,PaginaWeb,Facebook,"+
                "Whatsapp,Cod_Ente)values(@Nombre,@RazonSocial,@Nit,@Rubro,@Telefono,@Direccion,@NombreContacto,@Email,@EmailEnvio,@PaginaWeb,@Facebook,@Whatsapp,"+
                "@Cod_Ente);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@RazonSocial", obj.RazonSocial);
                cmd.Parameters.AddWithValue("@Nit", obj.Nit);
                cmd.Parameters.AddWithValue("@Rubro", obj.Rubro);
                cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                cmd.Parameters.AddWithValue("@NombreContacto", obj.NombreContacto);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@EmailEnvio",obj.EmailEnvio);
                cmd.Parameters.AddWithValue("@PaginaWeb", obj.PaginaWeb);
                cmd.Parameters.AddWithValue("@Facebook", obj.Facebook);
                cmd.Parameters.AddWithValue("@Whatsapp", obj.Whatsapp);
                cmd.Parameters.AddWithValue("@Cod_Ente",3);
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