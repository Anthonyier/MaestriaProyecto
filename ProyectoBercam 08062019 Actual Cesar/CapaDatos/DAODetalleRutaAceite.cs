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
    public class DAODetalleRutaAceite
    {
        public static bool GuardarDetalleAceite(EntDetalleRutaAceite Dra)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into DetalleRutaAceite (PrecioTotal,PrecioFletero,FechaInicio,FechaFinal,IdRuta) values" +
                    "(@PrecioTotal,@PrecioFletero,@FechaInicio,@FechaFinal,@IdRuta);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@PrecioTotal", Dra.PrecioTotal);
                cmd.Parameters.AddWithValue("@PrecioFletero", Dra.PrecioFletero);
                cmd.Parameters.AddWithValue("@FechaInicio", Dra.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFinal", Dra.FechaFinal);
                cmd.Parameters.AddWithValue("@IdRuta", Dra.IdRuta);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                return false;

            }
            myTrans.Commit();
            cnx.Close();
            return true;
        }
    }
}