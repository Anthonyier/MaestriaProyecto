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
using System.Transactions;

namespace CapaDatos
{
    public class DAOAdelanteoDePago
    {
        public static int Guardar(EntAdelantoDePago AdelPago)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into AdelantoDePago (Monto,IdPersona,FechaAdelanto) values (@Monto,@IdPersona,@FechaAdelanto);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Monto", AdelPago.Monto);
                cmd.Parameters.AddWithValue("@IdPersona", AdelPago.IdPersona);
                cmd.Parameters.AddWithValue("@FechaAdelanto", AdelPago.FechaAdelanto);
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
         public static EntPersona ObtenerIdMaestroProveedor(int IdPersona)
        {
            EntPersona Pers = new EntPersona();
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("isi_vinculacion_obtMaestroProv", cnx);
                cmd.Parameters.AddWithValue("@idPersona", IdPersona);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                Pers.Id_Persona = Convert.ToInt32(dr["id"].ToString());
                Pers.Nombres = dr["razon_social"].ToString();


            }
            catch (Exception e)
            {

                //obj.DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return Pers; //objDias
        }

        public static int ObtenerUsuario(int Usu)
        {

            int Us = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("isi_vinculacion_obtUsuario", cnx);
                cmd.Parameters.AddWithValue("@idUsuario", Usu);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Us = Convert.ToInt32(dr["idUsuario_isi"].ToString());

            }
            catch (Exception e)
            {

                //obj.DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return Us;

        }
        public static int GuardarImagenAdelantosAnidada(ref SqlConnection cnx, EntImagenesAdelantoDePagos obj)
        {
            int Id_ImagenAdelanto = 0;
            SqlCommand cmd = null;
            

            try
            {
              

                if (obj.Imagen != null)  //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update ImagenesAdelantoDePagos set Estado = 0 where IdAdelanto= " + obj.IdAdelanto, cnx);
                    
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into ImagenesAdelantoDePagos (Imagen,Nombre,Ext,IdAdelanto) values (@Imagen,@Nombre,@Ext,@IdAdelanto) ; SELECT Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Ext", obj.Ext);
                    cmd.Parameters.AddWithValue("@IdAdelanto", obj.IdAdelanto);
                   
                    int Id_ImgAdelanto = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenAdelanto = Id_ImgAdelanto;

                    if (Id_ImagenAdelanto != 0)
                    {

                    }
                }
            }
            catch (Exception e)
            {
               
                return 0;
            }
            finally
            {

            }
            return Id_ImagenAdelanto;
        }
        public static bool DInsertar(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesAdelantoDePagos Adelanto, int idTipoPago, int IdPasivo,int IdModPago,string Modalidad,int IdCuenta)
        {
            EntPersona PersonaMp = ObtenerIdMaestroProveedor(idPersona);
            int Us = ObtenerUsuario(idUsuario);
           string Resp= DInsertar1(fecha, idPersona, idUsuario, monto,Adelanto, idTipoPago, PersonaMp, Us, IdPasivo,IdModPago,Modalidad,IdCuenta);
           if (Resp == "ok")
           {
               return true;
           }
           else
           {
               return false;
           }
            //return "ok";
        }
        public static string DInsertar1(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesAdelantoDePagos Adelanto, int idTipoPago, EntPersona PersonaMp, int Us, int IdPasivo,int IdModPago,string Modalidad,int IdCuenta)
        {
            SqlConnection cnx = null;
            SqlCommand cmd = null;
            ClaseConexion Conexion = new ClaseConexion();
            string resp = "";
            string CompEgreso = "";
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    cnx = new SqlConnection();
                    cnx = Conexion.conectar();
                    cnx.Open();
                    cmd = new SqlCommand("isi_spGuardar_OrdenPago", cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter idOrdenPago = new SqlParameter("@idOrdenPago", SqlDbType.Int);
                    idOrdenPago.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(idOrdenPago);
                    cmd.Parameters.AddWithValue("@id", 0);
                    cmd.Parameters.AddWithValue("@fecha_Pago", fecha); //parametro
                    cmd.Parameters.AddWithValue("@moneda", "BOB");
                    cmd.Parameters.AddWithValue("@cod_acreedor", PersonaMp.Id_Persona); //se obtine
                    cmd.Parameters.AddWithValue("@tipoAcreedor", "P");
                    cmd.Parameters.AddWithValue("@nombreAcreedor", PersonaMp.Nombres); ////se obtine
                    cmd.Parameters.AddWithValue("@cod_sucursal", 1000);
                    cmd.Parameters.AddWithValue("@cod_tipo_pago", idTipoPago);
                    cmd.Parameters.AddWithValue("@cod_und_nego", 0);
                    cmd.Parameters.AddWithValue("@cod_tmc", 0);
                    cmd.Parameters.AddWithValue("@flujo_efectivo", "");
                    cmd.Parameters.AddWithValue("@glosa", "Adelanto De Pago Perteneciente A " + PersonaMp.Nombres);
                    cmd.Parameters.AddWithValue("@cod_mod_pago", IdModPago);
                    //cmd.Parameters.AddWithValue("@cod_mod_pago", 103);
                    //cmd.Parameters.AddWithValue("@sigla_banco", "FASSIL M/N");
                    //cmd.Parameters.AddWithValue("@nro_bancario", "909310");
                    cmd.Parameters.AddWithValue("@nro_doc_banco", "");
                    cmd.Parameters.AddWithValue("@nro_doc_bancario_original", "");
                    cmd.Parameters.AddWithValue("@fecha_documento", fecha); //parametro
                    cmd.Parameters.AddWithValue("@importe_total", monto); //parametro
                    //cmd.Parameters.AddWithValue("@id_cuenta_contable", 369);
                    if (IdCuenta == 15)
                    {
                        cmd.Parameters.AddWithValue("@Id_cuenta_Contable", IdCuenta);
                        cmd.Parameters.AddWithValue("@nro_bancario", "10000019655840");
                        cmd.Parameters.AddWithValue("@sigla_banco", "BUN M/N");
                    }
                    else if (IdCuenta == 8477)
                    {
                        cmd.Parameters.AddWithValue("@id_cuenta_contable", IdCuenta);
                        cmd.Parameters.AddWithValue("@nro_bancario", "7015084557397");
                        cmd.Parameters.AddWithValue("@sigla_banco", "BCP M/N");
                    }
                    cmd.Parameters.AddWithValue("@beneficiario_cheque", "");
                    cmd.Parameters.AddWithValue("@id_banco_prov", "");
                    cmd.Parameters.AddWithValue("@usuario", Us); //parametro



                    int IdAdelantos = GuardarImagenAdelantosAnidada(ref cnx, Adelanto);
                    if (IdAdelantos > 0)
                    {
                        int fila = cmd.ExecuteNonQuery();
                        if (fila > 0)
                        {

                            resp = "ok";

                            int idOrden = Convert.ToInt32(idOrdenPago.Value);
                            resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdAdelantos, IdPasivo);
                            string Codigo2 = ObtenerCodigo2(ref cnx, idOrden);
                            if (resp == "ok")
                                CompEgreso = DGuardarCompEgresoAutomatico(ref cnx, fecha, PersonaMp.Id_Persona, PersonaMp.Nombres, monto, idOrden, Us, Codigo2,Modalidad,IdCuenta);
                            if (CompEgreso == "ok")
                            {
                                scope.Complete();
                            }
                        }
                        else
                        {
                            resp = "error";
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            { resp = ex.Message; }
            finally { cnx.Close(); }

            return resp;
        }

        public static string ObtenerCodigo2(ref SqlConnection cnx, int idOrdenPago)
        {
            string Codigo = "";
            SqlCommand cmd = null;
            ClaseConexion cn = new ClaseConexion();
            try
            {
                cmd = new SqlCommand("BuscarCodigo2OrdenPago", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter resp = new SqlParameter("@resp", SqlDbType.NVarChar);
                resp.Size = 10;
                resp.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(resp);
                cmd.Parameters.AddWithValue("@IdPago", idOrdenPago);
                cmd.ExecuteNonQuery();
                Codigo = Convert.ToString(cmd.Parameters["@resp"].Value);
            }
            catch (Exception e)
            {
                Codigo = "No se Encontro El Codigo";
            }

            return Codigo;
        }

        public static string DGuardarCompEgresoAutomatico(ref SqlConnection cnx, DateTime Fecha, int IdPersona, string NombrePersona, double Monto, int IdOrdenPago, int IdUsuario, string Codigo2,string Modalidad,int IdCuenta)
        {
            string resp = "";
            string Deta1 = "";
            string Deta2 = "";
            double Debe = Monto;
            double Haber = Monto * -1;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_spGuardar_CompEgresoAnticipo", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter idCompEgreso = new SqlParameter("@idCompEgreso", SqlDbType.Int);
                idCompEgreso.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(idCompEgreso);
                cmd.Parameters.AddWithValue("@Tipo_Contab", "Automático");
                cmd.Parameters.AddWithValue("@Fecha_Contable", Fecha);
                cmd.Parameters.AddWithValue("@IdAcreedor", IdPersona);
                cmd.Parameters.AddWithValue("@NombreAcreedor", IdPersona + " | " + NombrePersona);
                cmd.Parameters.AddWithValue("@fecha_doc", Fecha);
                cmd.Parameters.AddWithValue("@imp_doc", Monto);
                cmd.Parameters.AddWithValue("@debe", Debe);
                cmd.Parameters.AddWithValue("@haber", Haber);

                cmd.Parameters.AddWithValue("@Tipo_Cambio", 6.96);
                cmd.Parameters.AddWithValue("@id_sucursal", 1000);
                cmd.Parameters.AddWithValue("@descripcion", "Adelanto De Pago Perteneciente A " + NombrePersona);
                cmd.Parameters.AddWithValue("@modalidad", Modalidad);
                //cmd.Parameters.AddWithValue("@modalidad", "TRANSFERENCIA ELECTRONICA");

                cmd.Parameters.AddWithValue("@id_OrdenPago", IdOrdenPago);
                cmd.Parameters.AddWithValue("@nro_pago", Codigo2);
                cmd.Parameters.AddWithValue("@usuario", IdUsuario);
                cmd.Parameters.AddWithValue("@Nro_Doc", "");

                int fila = cmd.ExecuteNonQuery();
                if (fila > 0)
                {
                    int idComp = Convert.ToInt32(idCompEgreso.Value);
                    Deta1 = DGuardarDetallesComprobanteEgresosAutomaticosDebe(ref cnx, Monto, NombrePersona, idComp);
                    Deta2 = DGuardarDetallesComprobanteEgresosAutomaticosHaber(ref cnx, Monto, NombrePersona, idComp,IdCuenta);
                    if (Deta1 == "ok" && Deta2 == "ok")
                    {
                        resp = "ok";
                    }

                }

            }
            catch (Exception ex)
            {

                resp = ex.Message;

            }
            return resp;

        }
        public static string DGuardarDetallesComprobanteEgresosAutomaticosDebe(ref SqlConnection cnx, double Monto, string texto, int idPadre)
        {
            string resp = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_spGuardar_DetalleCompEgreso", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@debe", Monto);
                cmd.Parameters.AddWithValue("@haber", 0);

                cmd.Parameters.AddWithValue("@imp_doc", Monto);
                cmd.Parameters.AddWithValue("@impbob", Monto);
                cmd.Parameters.AddWithValue("@impusd", Monto);
                cmd.Parameters.AddWithValue("@texto", "Adelanto De Pago Perteneciente A " + texto);

                cmd.Parameters.AddWithValue("@id_cuenta", 32);
                cmd.Parameters.AddWithValue("@id_padre", idPadre);
                int fila = cmd.ExecuteNonQuery();
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

        public static string DGuardarDetallesComprobanteEgresosAutomaticosHaber(ref SqlConnection cnx, double Monto, string texto, int idPadre,int IdCuenta)
        {
            string resp = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_spGuardar_DetalleCompEgreso", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@debe", 0);
                cmd.Parameters.AddWithValue("@haber", Monto);

                cmd.Parameters.AddWithValue("@imp_doc", -Monto);
                cmd.Parameters.AddWithValue("@impbob", -Monto);
                cmd.Parameters.AddWithValue("@impusd", -Monto);
                cmd.Parameters.AddWithValue("@texto", "Adelanto De Pago Perteneciente A " + texto);

                cmd.Parameters.AddWithValue("@id_cuenta", IdCuenta);
                cmd.Parameters.AddWithValue("@id_padre", idPadre);
                int fila = cmd.ExecuteNonQuery();
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
        public static int DEncontrarAdelantoDePago(int IdFactura)
        {
            int resp = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("isi_Proc_ConfirmarAdelantoPago", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cmd.Parameters.AddWithValue("@IdFactura", IdFactura);
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
        public static int DEnconAdelPagoRecibo(int IdConc)
        {
            int resp = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("isi_Proc_AdelPagoReciboConfirmado", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cmd.Parameters.AddWithValue("@IdConc", IdConc);
                cmd.Parameters.AddWithValue("@TipoConc", "CONCILIACION");
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
        public static int DEnconAdelPagoReciboAceite(int IdConc)
        {
            int resp = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("isi_Proc_AdelPagoReciboConfirmado", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cmd.Parameters.AddWithValue("@IdConc", IdConc);
                cmd.Parameters.AddWithValue("@TipoConc", "ACEITE");
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
        public static string DGuardarDetalle(ref SqlConnection cnx, int idOrden, double monto, DateTime fecha, int IdAnticip, int IdPasivo)
        {

            string resp = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_spGuardar_DetalleOrdenPagoLogistica", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@comprobante", 0);
                cmd.Parameters.AddWithValue("@nro_doc", 0);
                cmd.Parameters.AddWithValue("@fecha_doc", fecha);
                cmd.Parameters.AddWithValue("@tipo_doc", "Documento");
                cmd.Parameters.AddWithValue("@imp_total", 0);
                cmd.Parameters.AddWithValue("@imp_pagado", 0);
                cmd.Parameters.AddWithValue("@imp_a_cta", monto);
                cmd.Parameters.AddWithValue("@id_contrato", 0);
                cmd.Parameters.AddWithValue("@tipo_cont", 0);

                cmd.Parameters.AddWithValue("@id_conta", 0);
                cmd.Parameters.AddWithValue("@id_cta", IdPasivo);  //aqui idPasivo
                cmd.Parameters.AddWithValue("@id_pago", idOrden);
                cmd.Parameters.AddWithValue("@mat", 0);

                cmd.Parameters.AddWithValue("@idCodigo", IdAnticip);
                cmd.Parameters.AddWithValue("@tabla_codigo", "ImagenesAdelantoDePagos");

                int fila = cmd.ExecuteNonQuery();
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
        public static int TransformarAdelantoDePago(EntAdelantoDePago AdelPag)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            int IdAdel = 0;
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into AdelantoDePago (Monto,Estado,IdPersona,FechaAdelanto,FechaPago) values (@Monto,@Estado,@IdPersona,@FechaAdelanto,@FechaPago);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Monto", AdelPag.Monto);
                cmd.Parameters.AddWithValue("@Estado", AdelPag.Estado);
                cmd.Parameters.AddWithValue("@IdPersona", AdelPag.IdPersona);
                cmd.Parameters.AddWithValue("@FechaAdelanto", AdelPag.FechaAdelanto);
                cmd.Parameters.AddWithValue("@FechaPago", AdelPag.FechaPago);
                cmd.Transaction = myTrans;
                IdAdel = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                return IdAdel;

            }
            myTrans.Commit();
            cnx.Close();
            return IdAdel;
        }
        public static int ObtenerIdImagen(int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int IdAdelanto = 0;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            cnx.Open();
            try
            {

                cmd = new SqlCommand("Select Id from ImagenesAdelantoDePagos where IdAdelanto=@Id and Estado=1", cnx);
                cmd.Parameters.AddWithValue("@Id", IdDetalle);
                dr = cmd.ExecuteReader();
                dr.Read();
                IdAdelanto = Convert.ToInt32(dr["Id"].ToString());
            }
            catch (Exception e)
            {
                IdAdelanto = 0;
            }
            finally
            {
                cnx.Close();
            }
            return IdAdelanto;
        }
        public static int IdPersonaAdelanto(int id)
        {
            int IdPer = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("Select IdPersona from AdelantoDePago where Id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdPer = Convert.ToInt32(dr["IdPersona"].ToString());

            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return IdPer;
        }
        public static double EncontrarMonto(int id)
        {
            double Monto = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("Select Monto from AdelantoDePago where Id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Monto = Convert.ToDouble(dr["Monto"].ToString());

            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return Monto;
        }
        public static SqlDataReader ReaderAdelanto(int id)
        {
            //EntCamiones obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("EncontrarAdelantoDePago", cnx);
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

        public static void FechaPago(int id, DateTime FechaPagos)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "update AdelantoDePago set FechaPago=@FechaPago where Id=@Id;";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@FechaPago", FechaPagos);
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

        public static void Estado(int id)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "update AdelantoDePago set Estado=1 where Id=@Id;";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", id);
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
        public static void ActualizarAdelantoIdPago(int Id_Pmm, int Id)
        {
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();

            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "update AdelantoDePago set Id_Pmm=@Id_Pmm where Id=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id_Pmm", Id_Pmm);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        public static int InsertarPagoMasivoAdel()
        {
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            int IdPagoMasivo = 0;
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "insert into Pago_MasivoAdelLog (Activo) values(1);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Transaction = myTrans;
                IdPagoMasivo = Convert.ToInt32(cmd.ExecuteScalar());
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                return 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return IdPagoMasivo;
        }
        public static int VerificarYaPagadoAdel(int Id)
        {
            int IdPago = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select Id_Pmm from AdelantoDePago where Id =@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdPago = Convert.ToInt32(dr["Id_Pmm"].ToString());
                dr.Close();
            }
            catch (Exception e)
            {
                dr = null;
                return 0;
            }
            return IdPago;
        }
        public static int EncontrarIdPagoMasiv(int Id)
        {
            int IdPagoMasivo = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                string sql = "Select Id_Pmm from AdelantoDePago where id=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdPagoMasivo = Convert.ToInt32(dr["Id_Pmm"].ToString());
                dr.Close();
            }
            catch (Exception ex)
            {
                dr = null;
                return 0;
            }
            return IdPagoMasivo;
        }
    }
}