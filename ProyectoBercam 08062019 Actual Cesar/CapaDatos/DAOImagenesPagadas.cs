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
    public class DAOImagenesPagadas
    {
        public static int GuardarImagenes(EntImagenesPagadas  obj)//EntPersona obj, EntImagenes Ci, EntImagenes Licencia, EntImagenes Felcn, EntImagenes Rejap)
        {
            int Id_ImagenPagadas = 0;
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
                    cmd = new SqlCommand("Update ImagenesPagadas set Estado = 0 where IdConciliacion= " + obj.IdConciliacion, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into ImagenesPagadas (Imagen,nombre,Ext,IdConciliacion,FechaPago) values (@Imagen,@nombre,@Ext,@IdConciliacion,@FechaPago); ", cnx);
                    cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Ext", obj.Ext);
                    cmd.Parameters.AddWithValue("@IdConciliacion", obj.IdConciliacion);
                    cmd.Parameters.AddWithValue("@FechaPago", obj.FechaPago);
                    cmd.Transaction = myTrans;
                    Id_ImagenPagadas = Convert.ToInt32(cmd.ExecuteScalar());
                   
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
            return Id_ImagenPagadas;
        }
        public static int ObtenerEstadoImagen(int IdConciliacion)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int IdEstado = 0;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            cnx.Open();
            try
            {

                cmd = new SqlCommand("select Estado,IdConciliacion from ImagenesPagadas where Estado=1 and IdConciliacion=@IdConc", cnx);
                cmd.Parameters.AddWithValue("@IdConc", IdConciliacion);

                dr = cmd.ExecuteReader();
                dr.Read();
                IdEstado = Convert.ToInt32(dr["Estado"].ToString());
            }
            catch (Exception e)
            {
                IdEstado = 0;
            }
            finally
            {
                cnx.Close();
            }
            return IdEstado ;
        }
        public static int ObtenerEstadoImagenAceite(int IdConcAceite)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int IdEstado = 0;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            cnx.Open();
            try
            {

                cmd = new SqlCommand("select Estado,IdConciliacionAceite from ImagenesPagadas where Estado=1 and IdConciliacionAceite=@IdConc", cnx);
                cmd.Parameters.AddWithValue("@IdConc", IdConcAceite);

                dr = cmd.ExecuteReader();
                dr.Read();
                IdEstado = Convert.ToInt32(dr["Estado"].ToString());
            }
            catch (Exception e)
            {
                IdEstado = 0;
            }
            finally
            {
                cnx.Close();
            }
            return IdEstado;
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

        public static int GuardarImagenPagadaAnidada(ref SqlConnection cnx,EntImagenesPagadas Obj)
        {
            int Id_ImagenPagadas = 0;
            SqlCommand cmd = null;
            

            try
            {
               

                if (Obj.Imagen != null)  //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update ImagenesPagadas set Estado = 0 where IdConciliacion= " + Obj.IdConciliacion, cnx);
                    
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into ImagenesPagadas (Imagen,nombre,Ext,IdConciliacion,FechaPago) values (@Imagen,@nombre,@Ext,@IdConciliacion,@FechaPago);SELECT Scope_Identity();  ", cnx);
                    cmd.Parameters.AddWithValue("@Imagen", Obj.Imagen);
                    cmd.Parameters.AddWithValue("@nombre", Obj.Nombre);
                    cmd.Parameters.AddWithValue("@Ext", Obj.Ext);
                    cmd.Parameters.AddWithValue("@IdConciliacion", Obj.IdConciliacion);
                    cmd.Parameters.AddWithValue("@FechaPago", Obj.FechaPago);
                    Id_ImagenPagadas = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
           
                return 0;
            }
            finally
            {

            }
            return Id_ImagenPagadas;
        }
        public static bool DInsertar(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesPagadas ImgPagadas, int idTipoPago, int IdPasivo, int IdAdelanto,int IdDescuento, int IdFactura,int IdModPago,string Modalidad,int IdCuenta)
        {
            EntPersona PersonaMp = ObtenerIdMaestroProveedor(idPersona);
            int Us = ObtenerUsuario(idUsuario);
            string Resp=DInsertar1(fecha, idPersona, idUsuario, monto, ImgPagadas, idTipoPago, PersonaMp, Us, IdPasivo,IdAdelanto,IdDescuento,IdFactura,IdModPago,Modalidad,IdCuenta);
            if (Resp == "ok")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string DInsertar1(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesPagadas ImgPagadas, int idTipoPago, EntPersona PersonaMp, int Us, int IdPasivo, int IdAdelanto, int IdDescuento, int IdFactura,int IdModPago,string Modalidad,int IdCuenta)
        {
            SqlConnection cnx = null;
            SqlCommand cmd = null;
            ClaseConexion Conexion = new ClaseConexion();
            string resp = "";
            string CompEgreso = "";
            int IdCompensacion = 0;
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
                    cmd.Parameters.AddWithValue("@glosa", "Liquidacion Perteneciente A " + PersonaMp.Nombres);
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

                    int IdImgPagada = GuardarImagenPagadaAnidada(ref cnx, ImgPagadas);
                    if (IdImgPagada > 0)
                    {

                    int fila = cmd.ExecuteNonQuery();
                    if (fila > 0)
                    {

                        resp = "ok";

                        int idOrden = Convert.ToInt32(idOrdenPago.Value);
                        int IdTabla = 0;
                        if (IdAdelanto == 0 && IdDescuento == 0)
                        {
                            IdTabla = DEncontrarIdProvFactura(ref cnx, IdFactura);
                            resp = GuardarVinculacionPago(ref cnx, "Prov-Fac", IdImgPagada, IdTabla);
                            if (resp == "ok")
                            {
                                resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdTabla, IdPasivo, "Factura", "Prov-Fac");
                                resp = DActualizarDetalleOrdenPagoSinAdelanto(ref cnx, idOrden);
                                resp = DActulizarDetalleProvisionarFactura(ref cnx, IdTabla);

                                //resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdImgPagada, IdPasivo, "Documento", "ImagenesPagadas");
                            }
                        }
                        else
                        {
                            IdCompensacion = DEncontrarIdCompensacion( ref cnx,IdFactura);
                            IdTabla = DEncontrarRelacionCompensacionAcreedor(ref cnx,IdCompensacion);
                            resp = GuardarVinculacionPago(ref cnx, "Prov-TGA", IdImgPagada, IdTabla);
                            if (resp == "ok")
                            {
                                resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdTabla, IdPasivo, "Documento", "Prov-TGA");
                                resp = DActualizarDetalleOrdenPagoConAdelanto(ref cnx, idOrden);
                            }
                        }
                        string Codigo2 = ObtenerCodigo2(ref cnx, idOrden);
                        if (resp == "ok")
                        {
                            CompEgreso = DGuardarCompEgresoAutomatico(ref cnx, fecha, PersonaMp.Id_Persona, PersonaMp.Nombres, monto, idOrden, Us, Codigo2,IdCompensacion,Modalidad,IdCuenta);
                            if (CompEgreso == "ok")
                            {
                                scope.Complete();
                            }
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
        public static bool DReciboInsertar(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesPagadas ImgPagadas, int idTipoPago, int IdPasivo, int IdAdelanto, int IdDescuento,int IdModPago,string Modalidad,int IdCuenta)
        {
            EntPersona PersonaMp = ObtenerIdMaestroProveedor(idPersona);
            int Us = ObtenerUsuario(idUsuario);
            string Resp = DInsertarRecibo(fecha, idPersona, idUsuario, monto, ImgPagadas, idTipoPago, PersonaMp, Us, IdPasivo, IdAdelanto, IdDescuento,IdModPago,Modalidad,IdCuenta);
            if (Resp == "ok")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string DInsertarRecibo(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesPagadas ImgPagadas, int idTipoPago, EntPersona PersonaMp, int Us, int IdPasivo, int IdAdelanto, int IdDescuento,int IdModPago,string Modalidad,int IdCuenta)
        {
            SqlConnection cnx = null;
            SqlCommand cmd = null;
            ClaseConexion Conexion = new ClaseConexion();
            string resp = "";
            string CompEgreso = "";
            int IdCompensacion = 0;
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
                    cmd.Parameters.AddWithValue("@glosa", "Liquidacion Perteneciente A " + PersonaMp.Nombres);
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

                    int IdImgPagada = GuardarImagenPagadaAnidada(ref cnx, ImgPagadas);
                    if (IdImgPagada > 0)
                    {

                        int fila = cmd.ExecuteNonQuery();
                        if (fila > 0)
                        {

                            resp = "ok";

                            int idOrden = Convert.ToInt32(idOrdenPago.Value);
                            //int IdAcreedor = DEncontrarIdProveedorRecibo(ref cnx, idPersona);
                            int IdTabla = 0;
                            if (IdAdelanto == 0 && IdDescuento == 0)
                            {

                                IdTabla = DEncontrarIdProvRecibo(ref cnx, ImgPagadas.IdConciliacion);
                                resp = GuardarVinculacionPago(ref cnx, "Prov-TGA", IdImgPagada, IdTabla);
                                int NroRecibo = DEncontrarNroRecibo(ref cnx, ImgPagadas.IdConciliacion);
                                if (resp == "ok")
                                {
                                    resp = DGuardarDetalleReciboSinAdelDes(ref cnx, idOrden, monto, fecha, IdTabla, IdPasivo, "Recibo", "Prov-TGA",NroRecibo);
                                    resp = DActualizarDetalleOrdenPagoSinAdelantoRecibo(ref cnx, idOrden);
                                    //resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdImgPagada, IdPasivo, "Documento", "ImagenesPagadas");
                                }
                            }
                            else
                            {
                                IdCompensacion = DEncontrarIdCompRecibo(ref cnx, ImgPagadas.IdConciliacion);
                                IdTabla = DEncontrarRelacionCompensacionAcreedor(ref cnx, IdCompensacion);
                                resp = GuardarVinculacionPago(ref cnx, "Prov-TGA", IdImgPagada, IdTabla);
                                if (resp == "ok")
                                {
                                    resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdTabla, IdPasivo, "Documento", "Prov-TGA");
                                    resp = DActualizarDetalleOrdenPagoConAdelanto(ref cnx, idOrden);
                                }
                            }
                            string Codigo2 = ObtenerCodigo2(ref cnx, idOrden);
                            if (resp == "ok")
                            {
                                CompEgreso = DGuardarCompEgresoAutomatico(ref cnx, fecha, PersonaMp.Id_Persona, PersonaMp.Nombres, monto, idOrden, Us, Codigo2, IdCompensacion,Modalidad,IdCuenta);
                                if (CompEgreso == "ok")
                                {
                                    scope.Complete();
                                }
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
        public static string DActualizarDetalleOrdenPagoConAdelanto(ref SqlConnection cnx, int IdOrdenPago)
        {
            string resp = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd = new SqlCommand("ActualizarDetalleOPConAdelanto", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdOrdenPago", IdOrdenPago);
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

        public static string DActualizarDetalleOrdenPagoSinAdelanto(ref SqlConnection cnx, int IdOrdenPago)
        {
            string resp = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd = new SqlCommand("ActualizarDetalleOPSinAdelanto", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdOrdenPago", IdOrdenPago);
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

        public static string DActulizarDetalleProvisionarFactura(ref SqlConnection cnx, int IdDetProv)
        {
            string resp = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd = new SqlCommand("ActualizarDetalleProvisionFactura", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", IdDetProv);
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
        public static string DGuardarCompEgresoAutomatico(ref SqlConnection cnx, DateTime Fecha, int IdPersona, string NombrePersona, double Monto, int IdOrdenPago, int IdUsuario, string Codigo2, int IdCompensacion,string Modalidad,int IdCuenta)
        {
            string resp = "";
            string Deta1 = "";
            string Deta2 = "";
            double Debe = Monto;
            double haber = Monto * -1;
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
                cmd.Parameters.AddWithValue("@haber", haber);

                cmd.Parameters.AddWithValue("@Tipo_Cambio", 6.96);
                cmd.Parameters.AddWithValue("@id_sucursal", 1000);
                cmd.Parameters.AddWithValue("@descripcion", "Liquidacion Perteneciente A " + NombrePersona);
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
                    Deta1 = DGuardarDetallesComprobanteEgresosAutomaticosDebe(ref cnx, Monto, NombrePersona, idComp, IdCompensacion);
                    Deta2 = DGuardarDetallesComprobanteEgresosAutomaticosHaber(ref cnx, Monto, NombrePersona, idComp,IdCuenta);
                    if (Deta1 == "ok" && Deta2 == "ok")
                    {

                        resp = DActualizarEgresoLiq(ref cnx, idComp, IdOrdenPago);
                    }

                }

            }
            catch (Exception ex)
            {

                resp = ex.Message;

            }
            return resp;

        }
        public static string DGuardarDetallesComprobanteEgresosAutomaticosDebe(ref SqlConnection cnx, double Monto, string texto, int idPadre, int IdCompAcree)
        {
            string resp = "";
            string TextDesc = "";
            if (IdCompAcree == 0)
            {
                TextDesc = "LIQUIDACION Perteneciente A " + texto;
            }
            else
            {
                TextDesc = DobtenerTextoCompEgreso(ref cnx, IdCompAcree);
            }

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
                cmd.Parameters.AddWithValue("@texto", TextDesc);

                cmd.Parameters.AddWithValue("@id_cuenta", 92);
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
        public static string DobtenerTextoCompEgreso(ref SqlConnection cnx, int IdCompA)
        {
            string Texto = "";
            SqlCommand cmd = null;
            ClaseConexion cn = new ClaseConexion();
            try
            {
                cmd = new SqlCommand("isi_ProcEncontrarTextoCompAcreedor", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter resp = new SqlParameter("@Resp", SqlDbType.NVarChar);
                resp.Size = 500;
                resp.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(resp);
                cmd.Parameters.AddWithValue("@IdComp", IdCompA);
                cmd.ExecuteNonQuery();
                Texto = Convert.ToString(cmd.Parameters["@Resp"].Value);
            }
            catch (Exception e)
            {
                Texto = "No se Encontro El Texto";
            }

            return Texto;
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
                cmd.Parameters.AddWithValue("@texto", "LIQUIDACION Perteneciente A " + texto);

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

        public static string DActualizarEgresoLiq(ref SqlConnection cnx, int IdCompEgreso, int IdOrdenPago)
        {
            string resp = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd = new SqlCommand("ActualizarEgresoLiquiLogistica", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdComp", IdCompEgreso);
                cmd.Parameters.AddWithValue("@IdOrdenPago", IdOrdenPago);
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
        public static int DEncontrarIdProvRecibo(ref SqlConnection cnx, int IdConc)
        {
            int resp = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr = null;
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_EncontrarProvisionReciboId", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdConc", IdConc);
                cmd.Parameters.AddWithValue("@TipoConc", "CONCILIACION");
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }
            return resp;
        }
        public static int DEncontrarNroRecibo(ref SqlConnection cnx, int IdConc)
        {
            int resp = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr = null;
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_EncontrarProvisionReciboId", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdConc", IdConc);
                cmd.Parameters.AddWithValue("@TipoConc", "CONCILIACION");
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["Recibo"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }
            return resp;
        }
        public static int DEncontrarIdProvReciboAceite(ref SqlConnection cnx, int IdConc)
        {
            int resp = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr = null;
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_EncontrarProvisionReciboId", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdConc", IdConc);
                cmd.Parameters.AddWithValue("@TipoConc", "ACEITE");
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }
            return resp;
        }
        public static int DEncontrarNroReciboAceite(ref SqlConnection cnx, int IdConc)
        {
            int resp = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr = null;
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_EncontrarProvisionReciboId", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdConc", IdConc);
                cmd.Parameters.AddWithValue("@TipoConc", "ACEITE");
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["Recibo"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }
            return resp;
        }
        public static string DActualizarDetalleOrdenPagoSinAdelantoRecibo(ref SqlConnection cnx, int IdOrdenPago)
        {
            string resp = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd = new SqlCommand("ActuaDetOPSinAdelantoRecibo", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdOrdenPago", IdOrdenPago);
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
        public static int DEncontrarIdProvFactura(ref SqlConnection cnx,int IdFactura)
        {
            int resp = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr = null;
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_EncontrarProvisionarFacturaId", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFactura", IdFactura);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }
            return resp;
        }
        public static int DEncontrarIdCompensacion( ref SqlConnection cnx, int IdFactura)
        {
            int resp = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr = null;
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_EncontrarCompensacionAcreedorid", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFactura", IdFactura);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["idCompensacionA"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }

            return resp;
        }
        public static int DEncontrarIdCompRecibo(ref SqlConnection cnx, int IdConc)
        {
            int resp = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr = null;
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_ProcEncontrarIdCompRecibo", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdConc", IdConc);
                cmd.Parameters.AddWithValue("@TipoConc", "CONCILIACION");
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }

            return resp;
        }
        public static int DEncontrarIdCompReciboAceite(ref SqlConnection cnx, int IdConc)
        {
            int resp = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr = null;
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_ProcEncontrarIdCompRecibo", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdConc", IdConc);
                cmd.Parameters.AddWithValue("@TipoConc", "ACEITE");
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }

            return resp;
        }
        public static int DEncontrarRelacionCompensacionAcreedor(ref SqlConnection cnx,int IdCompensacion)
        {
            int resp = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr = null;
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_EncontrarRelacionCompensacionAcreedor", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCompensacion", IdCompensacion);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }
            return resp;
        }
        public static string GuardarVinculacionPago(ref SqlConnection cnx, string Nombre, int IdImagen, int IdProv)
        {
            string resp = "";
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("isi_ProcInsertarVinculacionPagoConciliaciones", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreTabla", Nombre);
                cmd.Parameters.AddWithValue("@Id_Imagen", IdImagen);
                cmd.Parameters.AddWithValue("@Id_Prov", IdProv);

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
        public static string DGuardarDetalle(ref SqlConnection cnx, int idOrden, double monto, DateTime fecha, int IdImgPagada, int IdPasivo, string TipoDoc, string TablaCodigo)
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
                cmd.Parameters.AddWithValue("@tipo_doc", TipoDoc);
                cmd.Parameters.AddWithValue("@imp_total", 0);
                cmd.Parameters.AddWithValue("@imp_pagado", 0);
                cmd.Parameters.AddWithValue("@imp_a_cta", monto);
                cmd.Parameters.AddWithValue("@id_contrato", 0);
                cmd.Parameters.AddWithValue("@tipo_cont", 0);

                cmd.Parameters.AddWithValue("@id_conta", 0);
                cmd.Parameters.AddWithValue("@id_cta", 92);  //aqui idPasivo
                cmd.Parameters.AddWithValue("@id_pago", idOrden);
                cmd.Parameters.AddWithValue("@mat", 0);

                cmd.Parameters.AddWithValue("@idCodigo", IdImgPagada);
                cmd.Parameters.AddWithValue("@tabla_codigo", TablaCodigo);

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
        public static string DGuardarDetalleReciboSinAdelDes(ref SqlConnection cnx, int idOrden, double monto, DateTime fecha, int IdImgPagada, int IdPasivo, string TipoDoc, string TablaCodigo,int NroRecibo)
        {
            string resp = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd = new SqlCommand("isi_spGuardar_DetalleOrdenPagoLogistica", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@comprobante", 0);
                cmd.Parameters.AddWithValue("@nro_doc", NroRecibo);
                cmd.Parameters.AddWithValue("@fecha_doc", fecha);
                cmd.Parameters.AddWithValue("@tipo_doc", TipoDoc);
                cmd.Parameters.AddWithValue("@imp_total", 0);
                cmd.Parameters.AddWithValue("@imp_pagado", 0);
                cmd.Parameters.AddWithValue("@imp_a_cta", monto);
                cmd.Parameters.AddWithValue("@id_contrato", 0);
                cmd.Parameters.AddWithValue("@tipo_cont", 0);

                cmd.Parameters.AddWithValue("@id_conta", 0);
                cmd.Parameters.AddWithValue("@id_cta", 92);  //aqui idPasivo
                cmd.Parameters.AddWithValue("@id_pago", idOrden);
                cmd.Parameters.AddWithValue("@mat", 0);

                cmd.Parameters.AddWithValue("@idCodigo", IdImgPagada);
                cmd.Parameters.AddWithValue("@tabla_codigo", TablaCodigo);

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
        public static int GuardarImagenAnidadaAceite(ref SqlConnection cnx, EntImagenesPagadas Obj)
        {
            int Id_ImagenPagadas = 0;
            SqlCommand cmd = null;


            try
            {


                if (Obj.Imagen != null)  //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update ImagenesPagadas set Estado = 0 where IdConciliacionAceite= " + Obj.IdConciliacionAceite, cnx);

                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into ImagenesPagadas (Imagen,nombre,Ext,IdConciliacionAceite,FechaPago) values (@Imagen,@nombre,@Ext,@IdConciliacionAceite,@FechaPago);SELECT Scope_Identity();  ", cnx);
                    cmd.Parameters.AddWithValue("@Imagen", Obj.Imagen);
                    cmd.Parameters.AddWithValue("@nombre", Obj.Nombre);
                    cmd.Parameters.AddWithValue("@Ext", Obj.Ext);
                    cmd.Parameters.AddWithValue("@IdConciliacionAceite", Obj.IdConciliacionAceite);
                    cmd.Parameters.AddWithValue("@FechaPago", Obj.FechaPago);
                    Id_ImagenPagadas = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {

                return 0;
            }
            finally
            {

            }
            return Id_ImagenPagadas;
        }
        public static bool DInsertarAceite(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesPagadas ImgPagadas, int idTipoPago, int IdPasivo, int IdAdelanto, int IdDescuento, int IdFactura,int IdModPago,string Modalidad,int IdCuenta)
        {
            EntPersona PersonaMp = ObtenerIdMaestroProveedor(idPersona);
            int Us = ObtenerUsuario(idUsuario);
            string Resp = DInsertar1Aceite(fecha, idPersona, idUsuario, monto, ImgPagadas, idTipoPago, PersonaMp, Us, IdPasivo, IdAdelanto,  IdDescuento,  IdFactura,IdModPago,Modalidad,IdCuenta);
            if (Resp == "ok")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string DInsertar1Aceite(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesPagadas ImgPagadas, int idTipoPago, EntPersona PersonaMp, int Us, int IdPasivo, int IdAdelanto, int IdDescuento, int IdFactura,int IdModPago,string Modalidad,int IdCuenta)
        {
            SqlConnection cnx = null;
            SqlCommand cmd = null;
            ClaseConexion Conexion = new ClaseConexion();
            string resp = "";
            string CompEgreso = "";
            int IdCompensacion = 0;
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
                    cmd.Parameters.AddWithValue("@glosa", "Liquidacion Perteneciente A " + PersonaMp.Nombres);
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

                    int IdImgPagada = GuardarImagenAnidadaAceite(ref cnx, ImgPagadas);
                    if (IdImgPagada > 0)
                    {

                        int fila = cmd.ExecuteNonQuery();
                        if (fila > 0)
                        {

                            resp = "ok";

                            int idOrden = Convert.ToInt32(idOrdenPago.Value);
                            int IdTabla = 0;
                            if (IdAdelanto == 0 && IdDescuento == 0)
                            {
                                IdTabla = DEncontrarIdProvFactura(ref cnx, IdFactura);
                                resp = GuardarVinculacionPago(ref cnx, "Prov-Fac", IdImgPagada, IdTabla);
                                if (resp == "ok")
                                {
                                    resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdTabla, IdPasivo, "Factura", "Prov-Fac");
                                    resp = DActualizarDetalleOrdenPagoSinAdelanto(ref cnx, idOrden);
                                    resp = DActulizarDetalleProvisionarFactura(ref cnx, IdTabla);

                                    //resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdImgPagada, IdPasivo, "Documento", "ImagenesPagadas");
                                }
                            }
                            else
                            {
                                IdCompensacion = DEncontrarIdCompensacion(ref cnx, IdFactura);
                                IdTabla = DEncontrarRelacionCompensacionAcreedor(ref cnx, IdCompensacion);
                                resp = GuardarVinculacionPago(ref cnx, "Prov-TGA", IdImgPagada, IdTabla);
                                if (resp == "ok")
                                {
                                    resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdTabla, IdPasivo, "Documento", "Prov-TGA");
                                    resp = DActualizarDetalleOrdenPagoConAdelanto(ref cnx, idOrden);
                                }
                            }
                            string Codigo2 = ObtenerCodigo2(ref cnx, idOrden);
                            if (resp == "ok")
                            {
                                CompEgreso = DGuardarCompEgresoAutomatico(ref cnx, fecha, PersonaMp.Id_Persona, PersonaMp.Nombres, monto, idOrden, Us, Codigo2, IdCompensacion,Modalidad,IdCuenta);
                                if (CompEgreso == "ok")
                                {
                                    scope.Complete();
                                }
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
        public static bool DReciboInsertarAceite(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesPagadas ImgPagadas, int idTipoPago, int IdPasivo, int IdAdelanto, int IdDescuento,int IdModPago,string Modalidad,int IdCuenta)
        {
            EntPersona PersonaMp = ObtenerIdMaestroProveedor(idPersona);
            int Us = ObtenerUsuario(idUsuario);
            string Resp = DInsertarReciboAceite(fecha, idPersona, idUsuario, monto, ImgPagadas, idTipoPago, PersonaMp, Us, IdPasivo, IdAdelanto, IdDescuento,IdModPago,Modalidad,IdCuenta);
            if (Resp == "ok")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string DInsertarReciboAceite(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesPagadas ImgPagadas, int idTipoPago, EntPersona PersonaMp, int Us, int IdPasivo, int IdAdelanto, int IdDescuento,int IdModPago,string Modalidad,int IdCuenta)
        {
            SqlConnection cnx = null;
            SqlCommand cmd = null;
            ClaseConexion Conexion = new ClaseConexion();
            string resp = "";
            string CompEgreso = "";
            int IdCompensacion = 0;
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
                    cmd.Parameters.AddWithValue("@glosa", "Liquidacion Perteneciente A " + PersonaMp.Nombres);
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

                    int IdImgPagada = GuardarImagenAnidadaAceite(ref cnx, ImgPagadas);
                    if (IdImgPagada > 0)
                    {

                        int fila = cmd.ExecuteNonQuery();
                        if (fila > 0)
                        {

                            resp = "ok";

                            int idOrden = Convert.ToInt32(idOrdenPago.Value);
                            //int IdAcreedor = DEncontrarIdProveedorRecibo(ref cnx, idPersona);
                            int IdTabla = 0;
                            if (IdAdelanto == 0 && IdDescuento == 0)
                            {

                                IdTabla = DEncontrarIdProvReciboAceite(ref cnx, ImgPagadas.IdConciliacionAceite);
                                resp = GuardarVinculacionPago(ref cnx, "Prov-TGA", IdImgPagada, IdTabla);
                                int NroRecibo = DEncontrarNroReciboAceite(ref cnx, ImgPagadas.IdConciliacionAceite);
                                if (resp == "ok")
                                {
                                    resp = DGuardarDetalleReciboSinAdelDes(ref cnx, idOrden, monto, fecha, IdTabla, IdPasivo, "Recibo", "Prov-TGA",NroRecibo);
                                    resp = DActualizarDetalleOrdenPagoSinAdelantoRecibo(ref cnx, idOrden);
                                    //resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdImgPagada, IdPasivo, "Documento", "ImagenesPagadas");
                                }
                            }
                            else
                            {
                                IdCompensacion = DEncontrarIdCompReciboAceite(ref cnx, ImgPagadas.IdConciliacionAceite);
                                IdTabla = DEncontrarRelacionCompensacionAcreedor(ref cnx, IdCompensacion);
                                resp = GuardarVinculacionPago(ref cnx, "Prov-TGA", IdImgPagada, IdTabla);
                                if (resp == "ok")
                                {
                                    resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdTabla, IdPasivo, "Documento", "Prov-TGA");
                                    resp = DActualizarDetalleOrdenPagoConAdelanto(ref cnx, idOrden);
                                }
                            }
                            string Codigo2 = ObtenerCodigo2(ref cnx, idOrden);
                            if (resp == "ok")
                            {
                                CompEgreso = DGuardarCompEgresoAutomatico(ref cnx, fecha, PersonaMp.Id_Persona, PersonaMp.Nombres, monto, idOrden, Us, Codigo2, IdCompensacion,Modalidad,IdCuenta);
                                if (CompEgreso == "ok")
                                {
                                    scope.Complete();
                                }
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
     
        public static int GuardarImagenAceite(EntImagenesPagadas obj)
        {
            int Id_ImagenPagadas = 0;
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
                    cmd = new SqlCommand("Update ImagenesPagadas set Estado = 0 where IdConciliacionAceite= " + obj.IdConciliacionAceite, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into ImagenesPagadas (Imagen,nombre,Ext,IdConciliacionAceite,FechaPago) values (@Imagen,@nombre,@Ext,@IdConciliacionAceite,@FechaPago); ", cnx);
                    cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Ext", obj.Ext);
                    cmd.Parameters.AddWithValue("@IdConciliacionAceite", obj.IdConciliacionAceite);
                    cmd.Parameters.AddWithValue("@FechaPago", obj.FechaPago);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
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
        public int ValorAceite(int IdDetalle)
        {
            int obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ValorAltaPagadasAceite", cnx);
                cmd.Parameters.AddWithValue("@IdConciliacionAceite", IdDetalle);
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

                cmd = new SqlCommand("ValorAltoPagadas", cnx);
                cmd.Parameters.AddWithValue("@IdConciliacion", IdDetalle);
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

        public static EntImagenesPagadas DownloadAceite(int id)
        {
            EntImagenesPagadas obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOImagenesPagadas Img = new DAOImagenesPagadas();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.ValorAceite(id);
            try
            {

                cmd = new SqlCommand("BuscarImagenPagada", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenesPagadas();
                dr.Read();

                obj.Nombre = dr["nombre"].ToString();
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

      
        public static EntImagenesPagadas Download(int Id)
        {
            EntImagenesPagadas obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOImagenesPagadas Img = new DAOImagenesPagadas();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.valor(Id);
            try
            {

                cmd = new SqlCommand("BuscarImagenPagada", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenesPagadas();
                dr.Read();

                obj.Nombre = dr["nombre"].ToString();
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

        public static EntImagenesPagadas ConsultaImagenAceite(int id)
        {
            EntImagenesPagadas obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOImagenesPagadas Img = new DAOImagenesPagadas();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.ValorAceite(id);
            try
            {

                cmd = new SqlCommand("BuscarImagenPagada", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenesPagadas();
                dr.Read();
                obj.Nombre = dr["nombre"].ToString();
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
        public static EntImagenesPagadas ConsultaImagen(int Id)
        {
            EntImagenesPagadas  obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOImagenesPagadas  Img = new DAOImagenesPagadas();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.valor(Id);
            try
            {

                cmd = new SqlCommand("BuscarImagenPagada", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenesPagadas();
                dr.Read();
                obj.Nombre= dr["nombre"].ToString();
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

    }
}