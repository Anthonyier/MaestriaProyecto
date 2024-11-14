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
    public class DOACuenta
    {
        public static EntCuenta ConsultaCuenta(long NroCuenta)
        {
            EntCuenta obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcConsultaCuenta", cnx);
                cmd.Parameters.AddWithValue("@NroCuenta", NroCuenta);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntCuenta();
                dr.Read();

                obj.Id_Cuenta = Convert.ToInt32(dr["Id_Cuenta"].ToString());
                obj.NroCuenta =Convert.ToInt64( dr["NroCuenta"].ToString());
                obj.Id_Banco = Convert.ToInt32(dr["Id_Banco"].ToString());
                obj.Id_TipoCuenta = Convert.ToInt32(dr["Id_TipoCuenta"].ToString());
                
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return obj;
        }

        public static SqlDataReader BuscarTitCuenta(string Ci)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcTitCuen", cnx);
                cmd.Parameters.AddWithValue("@Ci", Ci);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                //obj = new EntCamiones();
                //dr.Read();

                return dr;
            }
            catch (Exception e)
            {
                //obj = null;
                dr = null;
                return dr;
            }
           
        }
    }
}