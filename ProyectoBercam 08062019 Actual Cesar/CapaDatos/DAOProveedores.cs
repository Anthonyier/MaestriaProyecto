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
    public class DAOProveedores
    {

        public static int GuardarProveedores(EntProveedores obj)
        {
            SqlCommand cmd = null;
            int Cod_Ente = 0;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into Entes (Id_Tipo) values (1);SELECT Scope_Identity();"; //mientras se guarde persona lo dejamos que guarde 1, luego parametrizamos para que guarde tipoente2
                cmd = new SqlCommand(sql, cnx);
                cmd.Transaction = myTrans;
                Cod_Ente = Convert.ToInt32(cmd.ExecuteScalar());
                sql = "";

                sql = "Insert into Proveedores (CI,Nombre,Apellidos,Direccion,Telefono,TelfReferencia,Email,Emision," +
             "Cod_Ente)" +"values (@CI,@Nombre,@Apellidos,@Direccion,@Telefono,@TelfReferencia,@Email,@Emision,@Cod_Ente);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@CI", obj.CI);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", obj.Apellidos);
                cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("@TelfReferencia", obj.TelfReferencia);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Emision", obj.Emision);
                cmd.Parameters.AddWithValue("@Cod_Ente", Cod_Ente);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

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

        public EntProveedores BuscarProveedores(int IdProveedores)
        {
            EntProveedores obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
             ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("BuscarProveedores");
                cmd.Parameters.AddWithValue("@IdProd", IdProveedores);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                obj = new EntProveedores();
                dr = cmd.ExecuteReader();
                dr.Read();
                obj.Id_Proveedores = Convert.ToInt32(dr["Id_Proveedores"].ToString());
                obj.CI = dr["CI"].ToString();
                obj.Nombre = dr["Nombre"].ToString();
                obj.Apellidos = dr["Apellidos"].ToString();
                obj.Direccion = dr["Direccion"].ToString();
                obj.Telefono = dr["Telefono"].ToString();
                obj.TelfReferencia = dr["TelfReferencia"].ToString();

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