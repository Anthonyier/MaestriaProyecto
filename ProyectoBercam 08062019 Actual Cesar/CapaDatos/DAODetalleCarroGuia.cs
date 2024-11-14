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
    public class DAODetalleCarroGuia
    {
        public static int Guardar(EntDetalleCarroGuia Carro)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into DetalleCarroGuia (Monto,IdPersona,IdPeriodo,IdAño,IdRegion) values (@Monto,@IdPersona,@IdPeriodo,@IdAño,@IdRegion);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Monto", Carro.Monto);
                cmd.Parameters.AddWithValue("@IdPersona", Carro.IdPersona);
                cmd.Parameters.AddWithValue("@IdPeriodo",Carro.IdPeriodo);
                cmd.Parameters.AddWithValue("@IdAño", Carro.IdAño);
                cmd.Parameters.AddWithValue("@IdRegion", Carro.IdRegion);
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
        public static EntDetalleCarroGuia EncontrarDetalleCarroGuia(int IdPeriodo, int IdAño,int IdPersona,int IdRegion)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntDetalleCarroGuia DetalleGuia= null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select * from DetalleCarroGuia where IdPeriodo=@IdPeriodo and IdAño=@IdAño and IdPersona=@IdPersona and IdRegion=@IdRegion", cnx);
                cmd.Parameters.AddWithValue("@IdPeriodo", IdPeriodo);
                cmd.Parameters.AddWithValue("@IdAño", IdAño);
                cmd.Parameters.AddWithValue("@IdPersona", IdPersona);
                cmd.Parameters.AddWithValue("@IdRegion", IdRegion);
                cnx.Open();
                dr = cmd.ExecuteReader();
                DetalleGuia = new EntDetalleCarroGuia();
                dr.Read();
                DetalleGuia.id = Convert.ToInt32(dr["Id"].ToString());
                DetalleGuia.IdPeriodo = Convert.ToInt32(dr["IdPeriodo"].ToString());
                DetalleGuia.IdAño = Convert.ToInt32(dr["IdAño"].ToString());
            }
            catch (Exception e)
            {
                DetalleGuia  = null;
            }
            finally
            {
                cnx.Close();
            }
            return DetalleGuia ;
        }
        public static void Aprobar(int Periodo, int Año)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update DetalleCarroGuia set Solicitud=1 where IdPeriodo= " + Periodo + "and IdAño= " + Año + "and Solicitud=0;";
                cmd = new SqlCommand(sql, cnx);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cnx.Close();
            }
        }
    }
}