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
    public class DOAServicios
    {
        public static int GuardarServicios(EntServicios Ser)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into Servicios(Monto,Descripcion,IdPeriodo,IdAño,IdRegion,IdCamion) values (@Monto,@Descripcion,@IdPeriodo,@IdAño,@IdRegion,@IdCamion);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Monto", Ser.Monto);
                cmd.Parameters.AddWithValue("@Descripcion", Ser.Descripcion);
                cmd.Parameters.AddWithValue("@IdPeriodo", Ser.IdPeriodo);
                cmd.Parameters.AddWithValue("@IdAño", Ser.IdAño);
                cmd.Parameters.AddWithValue("@IdRegion", Ser.IdRegion);
                cmd.Parameters.AddWithValue("@IdCamion", Ser.IdCamion);
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