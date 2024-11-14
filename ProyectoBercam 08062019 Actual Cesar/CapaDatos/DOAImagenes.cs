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
    public class DOAImagenes
    {
        public static EntImagenes ConsultaImagenes(int Cod_Ente, int Tipo_Imagen)
        {
            EntImagenes obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcImagenes", cnx);
                cmd.Parameters.AddWithValue("@Cod_Ente", Cod_Ente);
                cmd.Parameters.AddWithValue("@Tipo_Imagen", Tipo_Imagen);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenes();
                dr.Read();
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
        public static EntImagenes ConsultaImagenes1(int Cod_Ente)
        {
            EntImagenes obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcImagenes", cnx);
                cmd.Parameters.AddWithValue("@Cod_Ente", Cod_Ente);
                //cmd.Parameters.AddWithValue("@Tipo_Imagen", Tipo_Imagen);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenes();
                dr.Read();
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
        public static bool EnviarCorreo(string Mensaje)
        {
            MailMessage msj = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                msj.From = new MailAddress("transbercamcorreo@gmail.com");
                msj.To.Add(new MailAddress("nvargas@transbercam.com.bo"));
                msj.Body = Mensaje;
                msj.Subject = "Vencimiento O Por Vencer Documento De Personas";
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
                msj.Subject = "Vencimiento De Documentos Persona";
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
        public static bool EnviarCorreoLuisHernan(string Mensaje)
        {
            MailMessage msj = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                msj.From = new MailAddress("transbercamcorreo@gmail.com");
                msj.To.Add(new MailAddress("luishernando@transbercam.com.bo"));
                msj.Body = Mensaje;
                msj.Subject = "Vencimiento O Por Vencer Documentos de Persona";
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

        public static bool EnviarCorreoNatalie(string Mensaje)
        {
            MailMessage msj = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                msj.From = new MailAddress("transbercamcorreo@gmail.com");
                msj.To.Add(new MailAddress("natymichelle@liquitrans.com.bo"));
                msj.Body = Mensaje;
                msj.Subject = "Vencimiento O Por Vencer Documentos de Persona";
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
        public static bool EnviarCorreoVillamontes(string Mensaje)
        {
            MailMessage msj = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                msj.From = new MailAddress("transbercamcorreo@gmail.com");
                msj.To.Add(new MailAddress("smsvll.transbercam@gmail.com"));
                msj.Body = Mensaje;
                msj.Subject = "Vencimiento O Por Vencer Documentos de Persona";
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                string fr = "transbercamcorreo@gmail.com";
                string pass = "kcqbzupdtnioterv";
                smtp.Credentials = new NetworkCredential(fr, pass);
                smtp.EnableSsl = true;
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
                msj.Subject = "Vencimiento O Por Vencer Documentos de Persona";
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
        public static SqlDataReader ObtenerListaPersona()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("Select * from vi_ListaDocumentosHabilitados", cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
               
            }
            catch (Exception e)
            {
                dr = null;
            }
            return dr;
        }
        public static SqlDataReader ObtenerListaPersonaAndres()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("Select * from vi_ListaDocumentosHabilitadosJoseLuis", cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();

            }
            catch (Exception e)
            {
                dr = null;
            }
            return dr;
        }
        public static int GuardarImagenes(EntImagenes obj)//EntPersona obj, EntImagenes Ci, EntImagenes Licencia, EntImagenes Felcn, EntImagenes Rejap)
        {
            int Id_ImagenCI = 0;
            int Id_ImagenLicencia = 0;
            int Id_ImagenFelcn = 0;
            int Id_ImagenRejap = 0;
            int Id_ImagenSegAcc = 0;
            int Id_ImagenSegVid = 0;
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            string sql = "";
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();

            try
            {
                
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                if ((obj.Tipo_Imagen == 1)) //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update Imagenes set Estado = 0 where Tipo_Imagen = 1 and Cod_Ente = " + obj.Cod_Ente, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into Imagenes (Cod_Ente,Vigencia, Tipo_Imagen,Aplica) values (@Cod_Ente,@Vigencia, @Tipo_Imagen,@Aplica) ;SELECT  Scope_Identity(); ", cnx);
                    
                    cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Vigencia", obj.Vigencia);
                    cmd.Parameters.AddWithValue("@Tipo_Imagen", obj.Tipo_Imagen);
                    cmd.Parameters.AddWithValue("@Aplica", obj.Aplica);
                    cmd.Transaction = myTrans;
                    int Id_ImgCI = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenCI = Id_ImgCI;

                }

                if ((obj.Tipo_Imagen == 2))
                {
                    cmd = new SqlCommand("Update Imagenes set Estado = 0 where Tipo_Imagen = 2 and Cod_Ente = " + obj.Cod_Ente, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    //imagen licencia
                    cmd = new SqlCommand("Insert into Imagenes (Cod_Ente,Vigencia, Tipo_Imagen) values (@Cod_Ente, @Vigencia, @Tipo_Imagen) ;SELECT  Scope_Identity(); ", cnx);
                    //(" + obj.Cod_Ente + "," + "'" + obj.Imagen + "'" + "," + "'" + obj.Vigencia + "'" + "," + obj.Tipo_Imagen
                    //+ ");SELECT  Scope_Identity();", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Vigencia", obj.Vigencia);
                    cmd.Parameters.AddWithValue("@Tipo_Imagen", obj.Tipo_Imagen);
                    cmd.Transaction = myTrans;
                    int Id_ImgLicencia = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenLicencia = Id_ImgLicencia;

                }

                if ( (obj.Tipo_Imagen == 3))//(Felcn.Imagen!= null)
                {
                    cmd = new SqlCommand("Update Imagenes set Estado = 0 where Tipo_Imagen = 3 and Cod_Ente = " + obj.Cod_Ente, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    //imagen licencia
                    cmd = new SqlCommand("Insert into Imagenes (Cod_Ente,Vigencia,Tipo_Imagen) values (@Cod_Ente, @Vigencia, @Tipo_Imagen) ;SELECT  Scope_Identity(); ", cnx);
                    //(" + obj.Cod_Ente + "," + "'" + obj.Imagen + "'" + "," + "'" + obj.Vigencia + "'" + "," + obj.Tipo_Imagen
                    //+ ");SELECT  Scope_Identity();", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Vigencia", obj.Vigencia);
                    cmd.Parameters.AddWithValue("@Tipo_Imagen", obj.Tipo_Imagen);
                    cmd.Transaction = myTrans;
                    int Id_ImgFelcn = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenFelcn = Id_ImgFelcn;

                }

                if ((obj.Tipo_Imagen == 4))//(Rejap.Imagen != null)
                {
                    cmd = new SqlCommand("Update Imagenes set Estado = 0 where Tipo_Imagen = 4 and Cod_Ente = " + obj.Cod_Ente, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    //imagen Rejap
                    cmd = new SqlCommand("Insert into Imagenes (Cod_Ente,Vigencia,Tipo_Imagen) values (@Cod_Ente, @Vigencia, @Tipo_Imagen) ;SELECT  Scope_Identity(); ", cnx);
                    //(" + obj.Cod_Ente + "," + "'" + obj.Imagen + "'" + "," + "'" + obj.Vigencia + "'" + "," + obj.Tipo_Imagen
                    //+ ");SELECT  Scope_Identity();", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Vigencia", obj.Vigencia);
                    cmd.Parameters.AddWithValue("@Tipo_Imagen", obj.Tipo_Imagen);
                    cmd.Transaction = myTrans;
                    int Id_ImgRejap = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenRejap = Id_ImgRejap;
                }
                if ((obj.Tipo_Imagen == 1002)) //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update Imagenes set Estado = 0 where Tipo_Imagen = 1002 and Cod_Ente = " + obj.Cod_Ente, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into Imagenes (Cod_Ente,Vigencia, Tipo_Imagen) values (@Cod_Ente,@Vigencia, @Tipo_Imagen) ;SELECT  Scope_Identity(); ", cnx);
                    //(" + obj.Cod_Ente + "," + "'" + obj.Imagen + "'" + "," + "'" + obj.Vigencia + "'" + "," + obj.Tipo_Imagen
                    //+ ");SELECT  Scope_Identity();", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Vigencia", obj.Vigencia);
                    cmd.Parameters.AddWithValue("@Tipo_Imagen", obj.Tipo_Imagen);
                    cmd.Transaction = myTrans;
                    int Id_ImgSegAcc = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenSegAcc = Id_ImgSegAcc;

                }
                if ((obj.Tipo_Imagen == 1003)) //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update Imagenes set Estado = 0 where Tipo_Imagen = 1003 and Cod_Ente = " + obj.Cod_Ente, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into Imagenes (Cod_Ente,Vigencia, Tipo_Imagen) values (@Cod_Ente, @Vigencia, @Tipo_Imagen) ;SELECT  Scope_Identity(); ", cnx);
                    //(" + obj.Cod_Ente + "," + "'" + obj.Imagen + "'" + "," + "'" + obj.Vigencia + "'" + "," + obj.Tipo_Imagen
                    //+ ");SELECT  Scope_Identity();", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Vigencia", obj.Vigencia);
                    cmd.Parameters.AddWithValue("@Tipo_Imagen", obj.Tipo_Imagen);
                    cmd.Transaction = myTrans;
                    int Id_ImgSegVid = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenSegVid = Id_ImgSegVid;

                    
                }
                if ((obj.Tipo_Imagen == 2002)) //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update Imagenes set Estado = 0 where Tipo_Imagen = 2002 and Cod_Ente = " + obj.Cod_Ente, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into Imagenes (Cod_Ente,Vigencia, Tipo_Imagen) values (@Cod_Ente, @Vigencia, @Tipo_Imagen) ;SELECT  Scope_Identity(); ", cnx);
                    //(" + obj.Cod_Ente + "," + "'" + obj.Imagen + "'" + "," + "'" + obj.Vigencia + "'" + "," + obj.Tipo_Imagen
                    //+ ");SELECT  Scope_Identity();", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Vigencia", obj.Vigencia);
                    cmd.Parameters.AddWithValue("@Tipo_Imagen", obj.Tipo_Imagen);
                    cmd.Transaction = myTrans;
                    int Id_CertMed = Convert.ToInt32(cmd.ExecuteScalar());
                }
                if ((obj.Tipo_Imagen == 2004)) //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update Imagenes set Estado = 0 where Tipo_Imagen = 2004 and Cod_Ente = " + obj.Cod_Ente, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into Imagenes (Cod_Ente,Vigencia, Tipo_Imagen) values (@Cod_Ente, @Vigencia, @Tipo_Imagen) ;SELECT  Scope_Identity(); ", cnx);
                    //(" + obj.Cod_Ente + "," + "'" + obj.Imagen + "'" + "," + "'" + obj.Vigencia + "'" + "," + obj.Tipo_Imagen
                    //+ ");SELECT  Scope_Identity();", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Vigencia", obj.Vigencia);
                    cmd.Parameters.AddWithValue("@Tipo_Imagen", obj.Tipo_Imagen);
                    cmd.Transaction = myTrans;
                    int Id_ManejDef=Convert.ToInt32(cmd.ExecuteScalar());
            
                }
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
        public static EntImagenes Download(int CodEnte, int TipoImg)
        {
            EntImagenes obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DOAImagenes Img = new DOAImagenes();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.valor(CodEnte, TipoImg);
            try
            {

                cmd = new SqlCommand("BuscarDocumento", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenes();
                dr.Read();

                obj.Nombre = dr["NombreDoc"].ToString();
                obj.Ext = dr["Ext"].ToString();
                obj.Imagen = (byte[])dr["ImagenP"];

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

        public static EntImagenes ConsultaImagen(int CodEnte, int TipoImg)
        {
            EntImagenes obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DOAImagenes Img = new DOAImagenes();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.valor(CodEnte, TipoImg);
            try
            {

                cmd = new SqlCommand("BuscarDocumento", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenes();
                dr.Read();

                obj.Nombre = dr["NombreDoc"].ToString();
                obj.Ext = dr["Ext"].ToString();

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
        public static int ActualizarImagenes(EntImagenes obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update DeImagen set Imagen=@Imagen,Vigencia=@Vigencia,Estado=@Estado where Id_Banco=@Id_Banco";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);
                cmd.Parameters.AddWithValue("@Vigencia", obj.Vigencia);
                cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                obj = null;
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
        public int valor(int CodEnte, int TipoImg)
        {
            int obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ValorAlto", cnx);
                cmd.Parameters.AddWithValue("@Cod_Ente", CodEnte);
                cmd.Parameters.AddWithValue("@Tipo_Img", TipoImg);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                obj = Convert.ToInt32(dr["Resultado"].ToString());


            }
            catch (Exception e)
            {
                obj = 0;
                //obj.DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return obj; //objDias
        } 
    }
}