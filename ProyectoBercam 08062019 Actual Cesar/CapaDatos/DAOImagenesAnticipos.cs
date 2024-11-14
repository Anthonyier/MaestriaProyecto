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
    public class DAOImagenesAnticipos
    {
        public static int GuardarImagenes(EntImagenesAnticipos obj)//EntPersona obj, EntImagenes Ci, EntImagenes Licencia, EntImagenes Felcn, EntImagenes Rejap)
        {
            int Id_ImagenAnticipo = 0;
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            string sql = "";

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                if (obj.Imagen != null)  //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update ImagenesAnticipos set Estado = 0 where IdDetalle= " + obj.IdDetalle, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into ImagenesAnticipos (Imagen,NombreDoc,Ext,IdDetalle) values (@Imagen,@NombreDoc,@Ext,@IdDetalle) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);
                    cmd.Parameters.AddWithValue("@NombreDoc", obj.NombreDoc);
                    cmd.Parameters.AddWithValue("@Ext", obj.Ext);
                    cmd.Parameters.AddWithValue("@IdDetalle", obj.IdDetalle);
                    cmd.Transaction = myTrans;
                    int Id_ImgAntc = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenAnticipo = Id_ImgAntc;

                    if (Id_ImagenAnticipo!= 0)
                    {
                        
                    }
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
            return Id_ImagenAnticipo;
        }


        public static string ObtenerNombre(int IdDetOrd)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string Nombre="";
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            cnx.Open();
            try
            {
                
                cmd = new SqlCommand("Select nombreAcreedor from isi_ordenPago where id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", IdDetOrd);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Nombre=dr["nombreAcreedor"].ToString();
            }
            catch (Exception e)
            {
                Nombre = "";
            }
            finally
            {
                cnx.Close();
            }
            return Nombre;
        }

        public static int ObtenerIdPago(int IdImagenAnticipo)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int IdPago = 0;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            cnx.Open();
            try
            {

                cmd = new SqlCommand("Select id_pago from isi_Detalle_OrdenPago where id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", IdImagenAnticipo);
                
                dr = cmd.ExecuteReader();
                dr.Read();
                IdPago = Convert.ToInt32(dr["id_pago"].ToString());
            }
            catch (Exception e)
            {
                IdPago = 0;
            }
            finally
            {
                cnx.Close();
            }
            return IdPago ;
        }
        public static void DeshabilitarOrdenPago(int Id)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            string sql = "";
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("update isi_OrdenPago set activo=0 where id=@Id",cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
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
        public static void DeshabilitarDetalleOrdenPago(int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            string sql = "";
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("update isi_Detalle_OrdenPago set activo=0 where id=@Id",cnx);
                cmd.Parameters.AddWithValue("@Id", IdDetalle);
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
        public static int ObtenerIdDetalleOrdenPago(int IdCodigo)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int IdDetallePago = 0;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            cnx.Open();
            try
            {

                cmd = new SqlCommand("Select id from isi_Detalle_OrdenPago where idCodigo=@Id and tabla_codigo='ImagenesAnticipos'", cnx);
                cmd.Parameters.AddWithValue("@Id", IdCodigo );
                
                dr = cmd.ExecuteReader();
                dr.Read();
                IdDetallePago = Convert.ToInt32(dr["id"].ToString());
            }
            catch (Exception e)
            {
                IdDetallePago = 0;
            }
            finally
            {
                cnx.Close();
            }
            return IdDetallePago;
        }
        public static void ModificarOrdenesPago(int IdImagenAnt,int IdImagenAdel)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            int IdPago = ObtenerIdPago(IdImagenAnt);
            string nombre=ObtenerNombre(IdPago);
            try
            {
                 ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                //cmd = new SqlCommand("Update isi_OrdenPago set glosa='Adelanto PARA " + nombre + " where id=@IdPago", cnx);
                //cmd.Parameters.AddWithValue("@IdPago", IdPago);
                //cmd.Transaction = myTrans;
                //cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Update isi_Detalle_OrdenPago set tabla_codigo = 'ImagenesAdelantoDePagos',idCodigo=@IdAdelanto where tabla_codigo='ImagenesAnticipos' and idCodigo= " + IdImagenAnt, cnx);
                cmd.Parameters.AddWithValue("@IdAdelanto", IdImagenAdel);
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
        public static void EliminarAnticipo(int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("update ImagenesAnticipos set Estado=0 where Estado=1 and IdDetalle= " + IdDetalle, cnx);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                cmd.Transaction = myTrans;
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

        public static void DeshabilitarAnticipo(int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            string Sql = "";
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("Update ImagenesAnticipos set Estado = 0 where IdDetalle= " + IdDetalle, cnx);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Update Detalle_Recepcion set FechaAnticipo=NULL,Enviado=0 where Id_Detalle=" + IdDetalle, cnx);
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
        public static int ObtenerIdImagen(int IdDetalle) {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int IdDetallePago = 0;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            cnx.Open();
            try
            {

                cmd = new SqlCommand("Select Id from ImagenesAnticipos where IdDetalle=@Id and Estado=1", cnx);
                cmd.Parameters.AddWithValue("@Id", IdDetalle);
                dr = cmd.ExecuteReader();
                dr.Read();
                IdDetallePago = Convert.ToInt32(dr["Id"].ToString());
            }
            catch (Exception e)
            {
                IdDetallePago = 0;
            }
            finally
            {
                cnx.Close();
            }
            return IdDetallePago;
       }
        public static int ValorImagen(int IdDetalle)
        {
            int obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ValorAltoAnticipo", cnx);
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle);
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

        public static bool DInsertar(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesAnticipos Anticip, int idTipoPago, int IdPasivo, int IdModPago, string Modalidad,int IdCuenta)
        {
            EntPersona PersonaMp = ObtenerIdMaestroProveedor(idPersona);
            int Us = ObtenerUsuario(idUsuario);
            string Resp=DInsertar1(fecha, idPersona, idUsuario, monto, Anticip, idTipoPago, PersonaMp, Us, IdPasivo,IdModPago,Modalidad,IdCuenta);
            if (Resp == "ok")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string DInsertar1(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesAnticipos Anticip, int idTipoPago, EntPersona PersonaMp, int Us, int IdPasivo, int IdModPago, string Modalidad,int IdCuenta)
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
                    cmd.Parameters.AddWithValue("@glosa", "ANTICIPO Perteneciente A " + PersonaMp.Nombres);
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

                    int fila = cmd.ExecuteNonQuery();

                    int IdAnticip = GuardarImagenAnticiposAnidada(ref cnx, Anticip);
                    if (IdAnticip > 0)
                    {
                        if (fila > 0)
                        {

                            resp = "ok";

                            int idOrden = Convert.ToInt32(idOrdenPago.Value);
                            resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdAnticip, IdPasivo);
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
            {
                resp = ex.Message; 
            }
            finally 
            { 
                cnx.Close(); 
            }

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
                cmd.Parameters.AddWithValue("@descripcion", "ANTICIPO Perteneciente A " + NombrePersona);
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
                cmd.Parameters.AddWithValue("@texto", "ANTICIPO Perteneciente A " + texto);

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
                cmd.Parameters.AddWithValue("@texto", "ANTICIPO Perteneciente A " + texto);

                //cmd.Parameters.AddWithValue("@id_cuenta", 369);
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

        public static int GuardarImagenAnticiposAnidada(ref SqlConnection cnx, EntImagenesAnticipos obj)
        {

            int Id_ImagenAnticipo = 0;
            SqlCommand cmd = null;
           
            try
            {

                if (obj.Imagen != null)  //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update ImagenesAnticipos set Estado = 0 where IdDetalle= " + obj.IdDetalle, cnx);
              
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into ImagenesAnticipos (Imagen,NombreDoc,Ext,IdDetalle) values (@Imagen,@NombreDoc,@Ext,@IdDetalle) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);
                    cmd.Parameters.AddWithValue("@NombreDoc", obj.NombreDoc);
                    cmd.Parameters.AddWithValue("@Ext", obj.Ext);
                    cmd.Parameters.AddWithValue("@IdDetalle", obj.IdDetalle);
                    int Id_ImgAntc = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenAnticipo = Id_ImgAntc;

                    if (Id_ImagenAnticipo != 0)
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
            return Id_ImagenAnticipo;
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
                cmd.Parameters.AddWithValue("@id_cta", IdPasivo);
                cmd.Parameters.AddWithValue("@id_pago", idOrden);
                cmd.Parameters.AddWithValue("@mat", 0);

                cmd.Parameters.AddWithValue("@idCodigo", IdAnticip);
                cmd.Parameters.AddWithValue("@tabla_codigo", "ImagenesAnticipos");

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
        public int valor(int IdDetalle)
        {
            int obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ValorAltoAnticipo", cnx);
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle);
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
        public static EntImagenesAnticipos Download(int Id)
        {
            EntImagenesAnticipos obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOImagenesAnticipos Img = new DAOImagenesAnticipos();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.valor(Id);
            try
            {

                cmd = new SqlCommand("BuscarImagenAnticipo", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenesAnticipos();
                dr.Read();

                obj.NombreDoc = dr["NombreDoc"].ToString();
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
        public static EntImagenesAnticipos TransImagen(int id)
        {
            EntImagenesAnticipos obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOImagenesAnticipos Img = new DAOImagenesAnticipos();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.valor(id);
            try
            {

                cmd = new SqlCommand("BuscarImagenAnticipo", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenesAnticipos();
                dr.Read();
                obj.Imagen = (byte[])dr["Imagen"];
                obj.NombreDoc = dr["NombreDoc"].ToString();
                obj.Ext = dr["Ext"].ToString();
                obj.IdDetalle = Convert.ToInt32(dr["IdDetalle"].ToString());

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

        public static EntImagenesAnticipos ConsultaImagenMod(int Id)
        {
            EntImagenesAnticipos obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOImagenesAnticipos Img = new DAOImagenesAnticipos();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.valor(Id);
            try
            {

                cmd = new SqlCommand("BuscarImagenAnticipo", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenesAnticipos();
                dr.Read();

                obj.IdDetalle= Convert.ToInt32(dr["IdDetalle"].ToString());

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
        public static EntImagenesAnticipos ConsultaImagen(int Id)
        {
            EntImagenesAnticipos  obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOImagenesAnticipos Img = new DAOImagenesAnticipos();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.valor(Id);
            try
            {

                cmd = new SqlCommand("BuscarImagenAnticipo", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenesAnticipos();
                dr.Read();

                obj.NombreDoc = dr["NombreDoc"].ToString();
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

        public static void ModificarFechaAnticipo(int IdDet, DateTime Fecha)
        {
            SqlCommand cmd = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            SqlTransaction myTrans = null;
            cnx.Open();
            myTrans = cnx.BeginTransaction();
            try
            {

                cmd = new SqlCommand("ModificarDetalleFechaAnticipo", cnx);
                cmd.Parameters.AddWithValue("@Id", IdDet);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            myTrans.Commit();
            cmd.Connection.Close();
            cnx.Close();
        }

        public static void ModificarImagen(int IdAnt, DateTime Fecha)
        {
            SqlCommand cmd = null;
            ClaseConexion cn =  new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            SqlTransaction myTrans = null;
            cnx.Open();
            myTrans = cnx.BeginTransaction();
            try
            {
                
                cmd = new SqlCommand("ModificarFechaImagenAnticipo", cnx);
                cmd.Parameters.AddWithValue("@Id", IdAnt);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            myTrans.Commit();
            cmd.Connection.Close();
            cnx.Close();
        }
        public static bool DInsertarCheqInter(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesAnticipos Anticip, int idTipoPago, int IdPasivo, string NroDocBanco, int IdModPago, string Modalidad,int IdCuenta)
        {

            EntPersona PersonaMp = ObtenerIdMaestroProveedor(idPersona);
            int Us = ObtenerUsuario(idUsuario);
            string Resp = DInsertarDetalleCheqInter(fecha, idPersona, idUsuario, monto, Anticip, idTipoPago, PersonaMp, Us, IdPasivo, NroDocBanco, IdModPago, Modalidad,IdCuenta);
            if (Resp == "ok")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string DInsertarDetalleCheqInter(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesAnticipos Anticip, int idTipoPago, EntPersona PersonaMp, int Us, int IdPasivo, string NroBancario, int IdModPago, string Modalidad,int IdCuenta)
        {
            SqlConnection cnx = null;
            SqlCommand cmd = null;
            ClaseConexion Conexion = null;
            string resp = "";
            string CompEgreso = "";
            double MontoBs = Math.Round(monto * 6.96,0);
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    cnx = new SqlConnection();
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
                    cmd.Parameters.AddWithValue("@glosa", "ANTICIPO Perteneciente A " + PersonaMp.Nombres);
                    cmd.Parameters.AddWithValue("@cod_mod_pago", IdModPago);
                    //cmd.Parameters.AddWithValue("@cod_mod_pago", 101);
                    cmd.Parameters.AddWithValue("@sigla_banco", "FASSIL");
                    cmd.Parameters.AddWithValue("@nro_bancario", "909420");
                    cmd.Parameters.AddWithValue("@nro_doc_banco", NroBancario);
                    cmd.Parameters.AddWithValue("@nro_doc_bancario_original", NroBancario);
                    cmd.Parameters.AddWithValue("@fecha_documento", fecha); //parametro
                    cmd.Parameters.AddWithValue("@importe_total", MontoBs); //parametro
                    cmd.Parameters.AddWithValue("@id_cuenta_contable", 369);
                    cmd.Parameters.AddWithValue("@beneficiario_cheque", "");
                    cmd.Parameters.AddWithValue("@id_banco_prov", "");
                    cmd.Parameters.AddWithValue("@usuario", Us); //parametro

                    int fila = cmd.ExecuteNonQuery();
                    int IdAnticip = GuardarImagenAnticiposAnidadaChequeInter(ref cnx, Anticip,NroBancario,monto);
                    if (IdAnticip > 0)
                    {
                        if (fila > 0)
                        {

                            resp = "ok";

                            int idOrden = Convert.ToInt32(idOrdenPago.Value);
                            resp = DGuardarDetalle(ref cnx, idOrden, MontoBs, fecha, IdAnticip, IdPasivo);
                            string Codigo2 = ObtenerCodigo2(ref cnx, idOrden);
                            if (resp == "ok")
                                CompEgreso = DGuardarCompEgresoAutomatico(ref cnx, fecha, PersonaMp.Id_Persona, PersonaMp.Nombres, MontoBs, idOrden, Us, Codigo2,Modalidad,IdCuenta);
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
            {
                resp = ex.Message;
            }
            finally
            {
                cnx.Close();
            }
            return resp;
        }
        public static int GuardarImagenAnticiposAnidadaChequeInter(ref SqlConnection cnx, EntImagenesAnticipos obj,string NroDocBanco,double MontoDolar)
        {

            int Id_ImagenAnticipo = 0;
            SqlCommand cmd = null;

            try
            {

                if (obj.Imagen != null)  //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update ImagenesAnticipos set Estado = 0 where IdDetalle= " + obj.IdDetalle, cnx);

                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into ImagenesAnticipos (Imagen,NombreDoc,Ext,IdDetalle,NroBancario,IdMoneda,MontoDolar) values (@Imagen,@NombreDoc,@Ext,@IdDetalle,@NroBancario,@IdMoneda,@MontoDolar) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);
                    cmd.Parameters.AddWithValue("@NombreDoc", obj.NombreDoc);
                    cmd.Parameters.AddWithValue("@Ext", obj.Ext);
                    cmd.Parameters.AddWithValue("@IdDetalle", obj.IdDetalle);
                    cmd.Parameters.AddWithValue("@NroBancario", NroDocBanco);
                    cmd.Parameters.AddWithValue("@IdMoneda", 2);
                    cmd.Parameters.AddWithValue("@MontoDolar", MontoDolar);
                    int Id_ImgAntc = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenAnticipo = Id_ImgAntc;

                    if (Id_ImagenAnticipo != 0)
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
            return Id_ImagenAnticipo;
        }
    }
}