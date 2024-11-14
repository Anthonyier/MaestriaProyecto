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
    public class DOADetalleCert
    {
        public static int GuardarImagenes(EntDetalle_Certificados obj)//EntPersona obj, EntImagenes Ci, EntImagenes Licencia, EntImagenes Felcn, EntImagenes Rejap)
        {
            int Id_ImagenCI = 0;
            int Id_ImagenLicencia = 0;
            int Id_ImagenFelcn = 0;
            int Id_ImagenRejap = 0;
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            string sql = "";

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                   
                        //actualizar las anteriores imagenes a estado=0 para que queden vigentes las ultimas realizadas o ingresadas...
                        cmd = new SqlCommand("Update Detalle_Certificados set Estado = 0 where Id_Certificado = "+obj.Id_Certificado  +" and Id_Camion = " + obj.Id_Camion , cnx);
                        cmd.Transaction = myTrans;
                        cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Insert into Detalle_Certificados (Id_Camion, Id_Certificado, FeVenci,Aplica) values (@Id_Camion, @Id_Certificado, @FeVenci,@Aplica) ;SELECT  Scope_Identity(); ", cnx);
                    //(" + obj.Cod_Ente + "," + "'" + obj.Imagen + "'" + "," + "'" + obj.Vigencia + "'" + "," + obj.Tipo_Imagen
                    //+ ");SELECT  Scope_Identity();", cnx);
                    cmd.Parameters.AddWithValue("@Id_Camion", obj.Id_Camion);
                    cmd.Parameters.AddWithValue("@Id_Certificado", obj.Id_Certificado);
                    cmd.Parameters.AddWithValue("@FeVenci", obj.Fecha_Vencimiento);
                    cmd.Parameters.AddWithValue("@Aplica", obj.Aplica);
                    cmd.Transaction = myTrans;
                    int Id_ImgCI = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenCI = Id_ImgCI;
                
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
        public static SqlDataReader ObtenerListaCamiones()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("Select * from vi_listaCamionCert", cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();

            }
            catch (Exception e)
            {
                dr = null;
            }
            return dr;
        }
        public static SqlDataReader ObtenerListaCamionesCarla()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion con = new ClaseConexion();
                SqlConnection cnx = con.conectar();
                cmd = new SqlCommand("Select * from ViewListaCamionesCarlaCert", cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                dr = null;
            }
            return dr;
        }
        public static SqlDataReader ObtenerListaCamionesCheckList()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion con = new ClaseConexion();
                SqlConnection cnx = con.conectar();
                cmd = new SqlCommand("Select * from ViewListaCamionesCheckListCert", cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                dr = null;
            }
            return dr;
        }
        public static SqlDataReader ObtenerListaCamionesAndres2()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion con = new ClaseConexion();
                SqlConnection cnx = con.conectar();
                cmd = new SqlCommand("Select * from ViewListaCamionesCarlaCert", cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                dr = null;
            }
            return dr;
        }
        public static SqlDataReader ObetenerListaCamionesAndres()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion con = new ClaseConexion();
                SqlConnection cnx = con.conectar();
                cmd = new SqlCommand("Select * from Vi_ListaCamionCertJoseLuis", cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                dr = null;
            }
            return dr;
        }
        public static SqlDataReader ObtenerListaCamionesExtintores()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion con = new ClaseConexion();
                SqlConnection cnx = con.conectar();
                cmd = new SqlCommand("Select * from Vi_ListaCamionCertExt ", cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                dr = null;
            }
            return dr;
        }
        public static bool EnviarCorreoCarla(string Mensaje)
        {
            MailMessage msj = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                msj.From = new MailAddress("transbercamcorreo@gmail.com");
                msj.To.Add(new MailAddress("carlamontano@transbercam.com.bo"));
                msj.Body = Mensaje;
                msj.Subject = "Documentos Por Vencer O ya Estan Vencidos";
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
        public static bool EnviarCorreoAndres(string Mensaje)
        {
            MailMessage msj = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                msj.From = new MailAddress("transbercamcorreo@gmail.com");
                msj.To.Add(new MailAddress("andressanabria@transbercam.com.bo"));
                msj.Body = Mensaje;
                msj.Subject = "Documentos Vencidos O Por Vencer Camiones";
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
        public static bool EnviarCorreoJefe(string Mensaje)
        {
            MailMessage msj = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                msj.From = new MailAddress("transbercamcorreo@gmail.com");
                msj.To.Add(new MailAddress("vribera@indsermaq.com.bo"));
                msj.Body = Mensaje;
                msj.Subject = "Documentos Vencidos O Por Vencer Camiones";
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
        public static bool EnviarCorreo(string Mensaje)
        {
            MailMessage msj = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                msj.From = new MailAddress("transbercamcorreo@gmail.com");
                msj.To.Add(new MailAddress("nvargas@transbercam.com.bo"));
                msj.Body = Mensaje;
                msj.Subject = "Documentos Vencidos Camiones";
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
        public static EntDetalle_Certificados Download(int Cod, int TipoImg)
        {
            EntDetalle_Certificados obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DOACamiones Ca = new DOACamiones();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Ca.valor(Cod, TipoImg);
            try
            {

                cmd = new SqlCommand("ProcImgCert", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntDetalle_Certificados();
                dr.Read();

                obj.Nombre = dr["NombreDoc"].ToString();
                obj.Ext = dr["Ext"].ToString();
                obj.Imagen = (byte[])dr["Imagen"];

            }
            catch (Exception e)
            {
                obj = null;
                //obj.DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return obj;
        }

        public static DateTime ObtenerFecha(EntDetalle_Certificados Obj)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntDetalle_Certificados  Cert =  new EntDetalle_Certificados();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select MAX(FeVenci) AS FeVenci from Detalle_Certificados where Estado=1 and Id_Certificado=@IdCertificado and Id_Camion=@IdCamion",cnx);
                cmd.Parameters.AddWithValue("@IdCertificado",Obj.Id_Certificado);
                cmd.Parameters.AddWithValue("@IdCamion", Obj.Id_Camion);
                cmd.CommandType = CommandType.Text;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Cert.Fecha_Vencimiento = Convert.ToDateTime(dr["FeVenci"].ToString());
                if(Cert.Fecha_Vencimiento==null)
                {
                    Cert.Fecha_Vencimiento=Convert.ToDateTime("01/01/2021");
                    return Cert.Fecha_Vencimiento;
                }
                else
                {
                    return Cert.Fecha_Vencimiento;
                }
            }
            catch(Exception ex)
            {
                Cert.Fecha_Vencimiento = Convert.ToDateTime("01/01/2021");
            }
            return Cert.Fecha_Vencimiento;
        }
    }
}