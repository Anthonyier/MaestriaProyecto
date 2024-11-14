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
    public class DAOAnticipo
    {
        public static int GuardarAnticipo(EntAnticipo  Ant)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into Anticipos (fecha,Monto,IdPeriodo,IdAño,IdRegion,IdCamion) values" +
                    "(@fecha,@Monto,@IdPeriodo,@IdAño,@IdRegion,@IdCamion);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@fecha", Ant.fecha);
                cmd.Parameters.AddWithValue("@Monto", Ant.Monto);
                cmd.Parameters.AddWithValue("@IdPeriodo", Ant.Periodo);
                cmd.Parameters.AddWithValue("@IdAño", Ant.Año);
                cmd.Parameters.AddWithValue("@IdRegion", Ant.Region);
                cmd.Parameters.AddWithValue("@IdCamion", Ant.IdCamion);
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
                //msj.To.Add(new MailAddress("anthonyribera@transbercam.com.bo"));
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
        public static EntAnticipo  ObtenerAnticipos(int Id)
        {
            EntAnticipo obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("Select * from Anticipos where id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntAnticipo();
                dr.Read();

                obj.Id = Convert.ToInt32(dr["id"].ToString());

                obj.fecha= Convert.ToDateTime(dr["fecha"].ToString());
                obj.Monto = Convert.ToDouble(dr["Monto"].ToString());
                obj.IdCamion = int.Parse (dr["IdCamion"].ToString());
                obj.Recp= int.Parse(dr["IdRecepcion"].ToString());
                obj.Derecp = Convert.ToInt32(dr["IdDetalleRecepcion"].ToString());
                obj.Estado = int.Parse(dr["Estado"].ToString());
                obj.Enviado = int.Parse(dr["Enviado"].ToString());

            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return obj;
        }

        public static int Confirmar(int Id)
        {
            int Env = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                //ClaseConexion cn = new ClaseConexion();
                //SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select Enviado from Detalle_Recepcion where Id_Detalle=@IdDetalle", cnx);
                cmd.Parameters.AddWithValue("@IdDetalle", Id);
                cmd.CommandType = CommandType.Text;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Env = int.Parse(dr["Enviado"].ToString());

            }
            catch (Exception e)
            {
                Env = 0;
                return Env;
            }
            finally
            {
                cmd.Connection.Close();

            }
            return Env;
        }
        public static SqlDataReader ReaderAnticipo(int id)
        {
            //EntCamiones obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("EncontrarAnticipRecp", cnx);
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

        public static void Enviado(int id)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Anticipo set Enviado=1 where IdRecepcion=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", id);
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
                cmd.Connection.Close();
            }
        }
    }
}