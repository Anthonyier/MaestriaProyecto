using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace CapaDatos
{
    public class DOAFacturaTrans
    {
        public static int GuardarFacturaTransp(EntFacturaTrans Fact)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert Into FacturaTrans(Factura,Descripcion,Monto,IdConciliacion) values (@Factura,@Descripcion,@Monto,@IdConciliacion);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Factura", Fact.factura);
                cmd.Parameters.AddWithValue("@Descripcion", Fact.Descripcion);
                cmd.Parameters.AddWithValue("@Monto", Fact.Monto);
                cmd.Parameters.AddWithValue("@IdConciliacion", Fact.IdConciliacion);
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

        public static int GuardarFacturaTransAceite(EntFacturaTrans Fact)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert Into FacturaTrans(Factura,Descripcion,Monto,IdConciliacionAceite) values (@Factura,@Descripcion,@Monto,@IdConciliacionAceite);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Factura", Fact.factura);
                cmd.Parameters.AddWithValue("@Descripcion", Fact.Descripcion);
                cmd.Parameters.AddWithValue("@Monto", Fact.Monto);
                cmd.Parameters.AddWithValue("@IdConciliacionAceite", Fact.IdConciliacionAceite);
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
        public static SqlDataReader ReaderFechaSolicitudAceite(int id)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ObtenerFechaSolicitudAceite", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
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
        public static SqlDataReader ReaderFechaSolicitud(int id)
        {
            //EntCamiones obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ObtenerFechaSolicitud", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
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
        public static int PendientedeSolicitud(int id)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update ConciliacionPorPagar set Solicitud=2, FechaSolicitud=@FechaSolicitud where id=@id and Solicitud=1 and Aprobado=0";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@id",id);
                cmd.Parameters.AddWithValue("@FechaSolicitud",Convert.ToDateTime(DateTime.Today));
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
        public static bool EnviarCorreo(string Mensaje)
        {
            MailMessage msj = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                msj.From = new MailAddress("transbercamcorreo@gmail.com");
                msj.To.Add(new MailAddress("vribera@indsermaq.com.bo"));
                //msj.To.Add(new MailAddress("anthonyriberas6v@gmail.com"));
                msj.Body = Mensaje;
                msj.Subject = "Pago De Anticipo";
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                string fr = "transbercamcorreo@gmail.com";
                //string pass = "transbercam12345";
                string pass = "kcqbzupdtnioterv";
                smtp.Credentials = new NetworkCredential(fr, pass);
                smtp.EnableSsl = true;
                //thread = new Thread(smtp.Send(msj));
                smtp.Send(msj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }
        public static void CambiarEstadoSolicitudes(int Periodo, int Año)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update ConciliacionPorPagar set Solicitud=2 where IdPeriodo=@IdPeriodo and IdAño=@IdAño and Aprobado=0 and Solicitud<>3";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@IdPeriodo", Periodo);
                cmd.Parameters.AddWithValue("@IdAño", Año);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            myTrans.Commit();
            cnx.Close();
        }

        public static int PendienteSolicitudAceite(int Id)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update ConciliacionPagarAceite set Solicitud=1,FechaSolicitud=@FechaSolicitud where id=@id and Solicitud=0 and Aprobado=0";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@FechaSolicitud",Convert.ToDateTime( DateTime.Today));
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
        public static void CambiarSolicitud(int Mes, int Año)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update ConciliacionPorPagar set Solicitud=2 where IdMes=@IdMes and IdAño=@IdAño and Aprobado=0 and Solicitud<>3";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@IdMes", Mes);
                cmd.Parameters.AddWithValue("@IdAño", Año);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            myTrans.Commit();
            cnx.Close();
        }
        public static double FacturaAnticipoAceite(int id)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            double Anticipo = 0;
            try
            {

                cmd = new SqlCommand("Select Anticipos from ConciliacionPagarAceite where Id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Anticipo = Convert.ToDouble(dr["Anticipos"].ToString());
            }
            catch (Exception e)
            {

            }
            finally
            {
                cnx.Close();
            }
            return Anticipo;
        }
        public static double FacturaAnticipo(int id)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            double Anticipo = 0;
            try
            {

                cmd = new SqlCommand("Select Anticipos from ConciliacionPorPagar where id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Anticipo = Convert.ToDouble(dr["Anticipos"].ToString());
            }
            catch (Exception e)
            {

            }
            finally
            {
                cnx.Close();
            }
            return Anticipo;
        }

        public static double PesoAPagable(int id)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            Double PorPagar = 0;
            try
            {

                cmd = new SqlCommand("Select TotalPagable from ConciliacionPagarAceite where Id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                PorPagar = Convert.ToDouble(dr["TotalPagable"].ToString());
            }
            catch (Exception e)
            {

            }
            finally
            {
                cnx.Close();
            }
            return PorPagar;
        }

        public static double LiquidoAPagar(int id)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            Double PorPagar= 0;
            try
            {

                cmd = new SqlCommand("Select TotalPagable from ConciliacionPorPagar where id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                PorPagar = Convert.ToDouble (dr["TotalPagable"].ToString());
            }
            catch (Exception e)
            {

            }
            finally
            {
                cnx.Close();
            }
            return PorPagar ;
        }
    }
}