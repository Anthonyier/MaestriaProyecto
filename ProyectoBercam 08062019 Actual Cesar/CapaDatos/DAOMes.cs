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
    public class DAOMes
    {
        public static string ObtenerMes(int id)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntMes Mes = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("select * from Mes where Id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                Mes = new EntMes ();
                dr.Read();
                Mes.Descripcion =dr["Descripcion"].ToString();

            }
            catch (Exception e)
            {
                Mes = null;
            }
            finally
            {
                cnx.Close();
            }

            return Mes.Descripcion;
        }
       
    }
}