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
    public class DAOAdelanto
    {
        public static int Guardar(EntAdelanto Adel)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into Adelantos (Monto,Descripcion,Fecha,IdTitular) values (@Monto,@Descripcion,@Fecha,@IdTitular);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Monto", Adel.Monto);
                cmd.Parameters.AddWithValue("@Descripcion", Adel.Descripcion);
                cmd.Parameters.AddWithValue("@Fecha", Adel.Fecha);
                cmd.Parameters.AddWithValue("@IdTitular", Adel.IdTitular);
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
        public static int DEncontrarDescuento(int IdFactura)
        {
            int resp = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("isi_Proc_ConfirmarDescuentos", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFactura", IdFactura);
                cnx.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["id"].ToString());
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                cnx.Close();
            }
            return resp;
        }
        public static int DEnconDescRecibo(int IdConc)
        {
            int resp = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("isi_Proc_DescuentoReciboConfirmado", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdConc", IdConc);
                cmd.Parameters.AddWithValue("@TipoConc", "CONCILIACION");
                cnx.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["id"].ToString());
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                cnx.Close();
            }
            return resp;
        }
        public static int DEnconDescReciboAceite(int IdConc)
        {
            int resp = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("isi_Proc_DescuentoReciboConfirmado", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdConc", IdConc);
                cmd.Parameters.AddWithValue("@TipoConc", "ACEITE");
                cnx.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["id"].ToString());
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                cnx.Close();
            }
            return resp;
        }
    }
}