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
    public class DAOCamionGuia
    {

        public static int GuardarCamionGuia(EntCamionGuia Cam)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into CamionetaGuia(Id_Guia,Monto,Año,Id_Proveedor,Periodo,IdRegion)"+
                    "values (@Id_Guia,@Monto,@Año,@Id_Proveedor,@Periodo,@IdRegion);Select Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id_Guia", Cam.Id_Guia);
                cmd.Parameters.AddWithValue("@Monto", Cam.Monto);
                cmd.Parameters.AddWithValue("@Año", Cam.Año);
                cmd.Parameters.AddWithValue("@Id_Proveedor",Cam.Id_Proveedor);
                cmd.Parameters.AddWithValue("@Periodo", Cam.Periodo);
                cmd.Parameters.AddWithValue("@IdRegion", Cam.IdRegion);
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

        public static int DetalleMax()
        {
            int Mx = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("MaximoCamionetaGuia", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Mx = Convert.ToInt32(dr["Maxim"].ToString());
            }
            catch (Exception e)
            {
                dr = null;
                return Mx;
            }
            return Mx;
        }

        public static EntCamionGuia EncontrarRepetidoCarroGuia(int IdPeriodo,int IdAño,int IdProveedor ,int IdRegion)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntCamionGuia CamGuia = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select * from CamionetaGuia where Periodo=@Periodo and Año=@Año and Id_Proveedor=@IdProveedor and IdRegion=@IdRegion", cnx);
                cmd.Parameters.AddWithValue("@Periodo", IdPeriodo);
                cmd.Parameters.AddWithValue("@Año", IdAño);
                cmd.Parameters.AddWithValue("@IdProveedor", IdProveedor);
                cmd.Parameters.AddWithValue("@IdRegion", IdRegion);
                cnx.Open();
                dr = cmd.ExecuteReader();
                CamGuia = new EntCamionGuia();
                dr.Read();
                CamGuia.Id_Guia = Convert.ToInt32(dr["Id_guia"].ToString());
                CamGuia.Periodo = Convert.ToInt32(dr["Periodo"].ToString());
                CamGuia.Año = Convert.ToInt32(dr["Año"].ToString());
            }
            catch (Exception e)
            {
                CamGuia = null;
            }
            finally
            {
                cnx.Close();
            }
            return CamGuia;
        }
    }
}