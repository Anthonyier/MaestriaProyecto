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
    public class DAOBitacora
    {
        public static int GuardarBitacora(EntBitacora bit)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into Bitacora(Usuario,Accion,IdUsuario) values (@Usuario,@Accion,@IdUsuario);Select Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Usuario", bit.Usuario);
                cmd.Parameters.AddWithValue("@Accion", bit.Accion);
                cmd.Parameters.AddWithValue("@IdUsuario", bit.IdUsuario);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                bit = null;
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

        public static int NumeroDeUsuario(string nombre, string apellido)
        {
            int num = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("IDUsuario", cnx);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                num = Convert.ToInt32(dr["Id_Usuario"].ToString());

            }
            catch (Exception e)
            {
                num = 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return num;
        }

        public static int NumeroDeEntrada(int Dia, int Mes,int Año,int IdUsuario)
        {
            int Numero = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcNumeroDeLogeo",cnx);
                cmd.Parameters.AddWithValue("@Dia", Dia);
                cmd.Parameters.AddWithValue("@Mes", Mes);
                cmd.Parameters.AddWithValue("@Año", Año);
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Numero = Convert.ToInt32(dr["Cantidad"].ToString());
            }
            catch (Exception e)
            {
                Numero = 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return Numero;
        }
    }
}