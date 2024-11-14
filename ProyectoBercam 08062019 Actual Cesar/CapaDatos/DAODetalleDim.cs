using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace CapaDatos
{
    public class DAODetalleDim
    {
        public static int InsertarDetalleDim(DateTime FechaPrm,string PrmNo,int IdDim,int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            int DDim = 0;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("ProcInsertarDetalleDim", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaPRM", FechaPrm);
                cmd.Parameters.AddWithValue("@PRMno", PrmNo);
                cmd.Parameters.AddWithValue("@IDim", IdDim);
                cmd.Parameters.AddWithValue("@Id_Detalle", IdDetalle);
                cmd.Transaction=myTrans;
                cmd.ExecuteNonQuery();
                DDim = 1;
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                DDim = 0;
                return DDim;
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
            return DDim;
        }
        public static string  InsDetalleDim(ref SqlConnection cnx,EntDetalleDim DetDim,int DimId)
        {
           
            string resp = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd = new SqlCommand("ProcInsertarDetalleDim", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaPRM", DetDim.FechaPRM);
                cmd.Parameters.AddWithValue("@PRMno", DetDim.PRMno);
                cmd.Parameters.AddWithValue("@IdDim", DimId);
                cmd.Parameters.AddWithValue("@Id_Detalle", DetDim.IdDetalle);
                int fila=cmd.ExecuteNonQuery();
                if (fila > 0)
                {
                    resp = "ok";
                }
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
          
            return resp;
        }
        public static string InserAddDetalleDim(List<EntDetalleDim> ListDetDim,int DimId)
        {
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            string resp = "OK";
            ClaseConexion Conexion = new ClaseConexion();
            try
            {
                using (TransactionScope scope = new TransactionScope())
               {
                   cnx = new SqlConnection();
                   cnx = Conexion.conectar();
                   cnx.Open();
                   for (int i = 0; i < ListDetDim.Count; i++)
                   {
                       EntDetalleDim DetDim = ListDetDim[i];
                       cmd = new SqlCommand("ProcInsertarDetalleDim", cnx);
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.AddWithValue("@FechaPRM", DetDim.FechaPRM);
                       cmd.Parameters.AddWithValue("@PRMno", DetDim.PRMno);
                       cmd.Parameters.AddWithValue("@VolumenPRM", DetDim.VolumenPRM);
                       cmd.Parameters.AddWithValue("@PesoPRM", DetDim.PesoPRM);
                       cmd.Parameters.AddWithValue("@IdDim", DimId);
                       cmd.Parameters.AddWithValue("@Id_Detalle", DetDim.IdDetalle);
                       int fila = cmd.ExecuteNonQuery();
                       if (fila > 0)
                       {
                           resp = "OK";
                       }
                       else
                       {
                           resp = "Error";
                       }
                   }
                   if (resp == "OK")
                   {
                       scope.Complete();
                   }
                }
                    
            }   
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                cnx.Close();
            }
            return resp;
        }
        public static bool EditarDetalleDim(EntDetalleDim Obj)
        {
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            bool Editado = false;
            ClaseConexion Conexion=new ClaseConexion();
            SqlTransaction myTrans = null;
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("Proc_Isi_ModDetalleDim", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Obj.Id);
                cmd.Parameters.AddWithValue("@Fecha", Obj.FechaPRM);
                cmd.Parameters.AddWithValue("@PrmNo", Obj.PRMno);
                cmd.Parameters.AddWithValue("@VolumenPrm", Obj.VolumenPRM);
                cmd.Parameters.AddWithValue("@PesoPrm", Obj.PesoPRM);
                cmd.Transaction = myTrans;
                int fila=cmd.ExecuteNonQuery();
                myTrans.Commit();
                if (fila > 0)
                {
                    Editado = true;
                }
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                Editado = false;
                return Editado;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return Editado;
        }
        public static EntDetalleDim ObtenerDetalleDim(int Id)
        {
            SqlCommand cmd = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = null;
            SqlDataReader dr = null;
            EntDetalleDim obj = null;
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("ProcBuscarDetalleDim", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                dr = cmd.ExecuteReader();
                obj = new EntDetalleDim();
                dr.Read();

                obj.Id = Convert.ToInt32(dr["Id"].ToString());
                obj.FechaPRM = Convert.ToDateTime(dr["FechaPRM"].ToString());
                obj.PRMno = dr["PRMno"].ToString();
                obj.VolumenPRM = Convert.ToDouble(dr["VolumenPRM"].ToString());
                obj.PesoPRM = Convert.ToDouble(dr["PesoPRM"].ToString());
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                cnx.Close();
            }
            return obj;
        }
        public static int ObtenerIdDetalleRecepcionDim(int id)
        {
            SqlCommand cmd = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = null;
            SqlDataReader dr = null;
            int IdDetalle = 0;
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("ProcEncontrarIdDetalleRecepcionDim", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                dr = cmd.ExecuteReader();
                dr.Read();
                IdDetalle = Convert.ToInt32(dr["Id_Detalle"].ToString());
            }
            catch (Exception ex)
            {
                IdDetalle = 0;
            }
            finally
            {
                cnx.Close();
            }
            return IdDetalle;
        }
        public static bool EditarDetalleRecepcionDatosDim(EntDetalle_Recepcion Obj)
        {
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            bool Editado = false;
            ClaseConexion Conexion = new ClaseConexion();
            SqlTransaction myTrans = null;
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("ProcActualizarDatosDimDetalleRecepcion", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NoCrt", Obj.NoCrt);
                cmd.Parameters.AddWithValue("@VolumenCrt", Obj.VolumenCrt);
                cmd.Parameters.AddWithValue("@PesoCrt", Obj.PesoCrt);
                cmd.Parameters.AddWithValue("@NoMic", Obj.NoMic);
                cmd.Parameters.AddWithValue("@VolumenMic", Obj.VolumenMic);
                cmd.Parameters.AddWithValue("@PesoMic", Obj.PesoMic);
                cmd.Parameters.AddWithValue("@IdDetalle", Obj.Id_Detalle);
                cmd.Transaction = myTrans;
                int Fila = cmd.ExecuteNonQuery();
                myTrans.Commit();
                if (Fila > 0)
                {
                    Editado = true;
                }
            }
            catch (Exception ex)
            {
                Editado = false;
                myTrans.Rollback();
                return Editado;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return Editado;
        }

        public static EntDetalle_Recepcion ObtenerValoresDetRecpDim(int Id)
        {
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlDataReader dr = null;
            EntDetalle_Recepcion Obj = new EntDetalle_Recepcion();
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("ProcObtenerValoresDetRececpDim", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                dr = cmd.ExecuteReader();
                dr.Read();
                Obj.NoCrt = dr["NoCrt"].ToString();
                Obj.VolumenCrt = Convert.ToDouble(dr["VolumenCrt"].ToString());
                Obj.PesoCrt = Convert.ToDouble(dr["PesoCrt"].ToString());
                Obj.NoMic = dr["NoMic"].ToString();
                Obj.VolumenMic = Convert.ToDouble(dr["VolumenMic"].ToString());
                Obj.PesoMic = Convert.ToDouble(dr["PesoMic"].ToString());
            }
            catch (Exception ex)
            {
                Obj = null;
            }
            finally
            {
                cnx.Close();
            }
            return Obj;
        }
        public static double DObtenerTotalVolPrmDim(int IdDim)
        {
            SqlCommand cmd = null;
            ClaseConexion conexion = new ClaseConexion();
            SqlConnection cnx = null;
            SqlDataReader dr = null;
            double VolPrm = 0;
            try
            {
                cnx = new SqlConnection();
                cnx = conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("ProcSumVolPRM ", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDim", IdDim);
                dr = cmd.ExecuteReader();
                dr.Read();
                VolPrm = Convert.ToDouble(dr["TotalVolumenPRM"].ToString());
            }
            catch (Exception ex)
            {
                VolPrm = 0;
            }
            finally
            {
                cnx.Close();
            }
            return VolPrm;
        }
    }
}