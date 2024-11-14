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
    public class DAODetalleMulta
    {

        public static int GuardarDetalleMulta(EntDetalleMulta Mu,string Obs,string Placa)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into Detalle_Multa(Precio,FechaRegistro,IdCamion,IdMulta,IdPeriodo,IdAño,IdRegion) values(@Precio,@FechaRegistro,@IdCamion,@IdMulta,@IdPeriodo,@IdAño,@IdRegion);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Precio", Mu.Precio);
                cmd.Parameters.AddWithValue("@FechaRegistro", Mu.Fecharegistro);
                cmd.Parameters.AddWithValue("@IdCamion", Mu.IdCamion);
                cmd.Parameters.AddWithValue("@IdMulta", Mu.IdMulta);
                cmd.Parameters.AddWithValue("@IdPeriodo", Mu.IdPeriodo);
                cmd.Parameters.AddWithValue("@IdAño", Mu.IdAño);
                cmd.Parameters.AddWithValue("@IdRegion", Mu.IdRegion);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                sql = "Update Camiones set OBS=@Obs where Placa=@Placa";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa);
                cmd.Parameters.AddWithValue("@Obs", Obs);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();

            }
            myTrans.Commit();
            cnx.Close();
            return 1;
        }
    }
}