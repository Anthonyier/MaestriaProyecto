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
    public class DAOKilometraje
    {
        public static int GuardarKilometraje(EntKilometraje Kilo)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into Kilometraje(Kilometraje,idRuta) values(@Kilometraje,@idRuta);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Kilometraje", Kilo.Kilometrajes);
                cmd.Parameters.AddWithValue("@idRuta", Kilo.IdRuta);
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
        public static EntKilometraje RepetidosKilometrajes(int idRuta)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntKilometraje rep = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("RepetidosKilometraje", cnx);
                cmd.Parameters.AddWithValue("@IdRuta",idRuta);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                rep = new EntKilometraje();
                dr.Read();
                rep.Id = Convert.ToInt32(dr["id"].ToString());
                rep.Kilometrajes = Convert.ToInt32(dr["Kilometraje"].ToString());

            }
            catch (Exception e)
            {
                rep = null;
            }
            finally
            {
                cnx.Close();
            }

            return rep;
        }
    }
}