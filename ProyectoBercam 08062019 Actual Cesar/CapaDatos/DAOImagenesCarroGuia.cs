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
    public class DAOImagenesCarroGuia
    {
        public static int GuardarImagenes(EntImagenesCarroGuia  obj)//EntPersona obj, EntImagenes Ci, EntImagenes Licencia, EntImagenes Felcn, EntImagenes Rejap)
        {
            int Id_ImagenCarroGuia= 0;
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
                    cmd = new SqlCommand("Update ImagenesCarroGuia set Estado = 0 where IdConciliacionCarroGuia= " + obj.IdConciliacionCarroGuia, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into ImagenesCarroGuia (Imagen,nombre,ext,IdConciliacionCarroGuia,FechaPago) values (@Imagen,@nombre,@ext,@IdConciliacionCarroGuia,@FechaPago) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);
                    cmd.Parameters.AddWithValue("@nombre", obj.NombreDoc);
                    cmd.Parameters.AddWithValue("@ext", obj.Ext);
                    cmd.Parameters.AddWithValue("@IdConciliacionCarroGuia", obj.IdConciliacionCarroGuia);
                    cmd.Parameters.AddWithValue("@FechaPago", obj.FechaPago);
                    cmd.Transaction = myTrans;
                    int Id_ImgCarroGuia = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenCarroGuia  = Id_ImgCarroGuia ;

                    if (Id_ImagenCarroGuia != 0)
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
            return 1;
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

                cmd = new SqlCommand("ValorAltoCarroGuia", cnx);
                cmd.Parameters.AddWithValue("@IdConciliacionCarroGuia", IdDetalle);
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

                cmd = new SqlCommand("ValorAltoCarroGuia", cnx);
                cmd.Parameters.AddWithValue("@IdConciliacionCarroGuia", IdDetalle);
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
        public static EntImagenesCarroGuia Download(int Id)
        {
            EntImagenesCarroGuia obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOImagenesCarroGuia  Img = new DAOImagenesCarroGuia ();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.valor(Id);
            try
            {

                cmd = new SqlCommand("BuscarImagenCarroGuia", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenesCarroGuia();
                dr.Read();

                obj.NombreDoc = dr["nombre"].ToString();
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

        public static EntImagenesCarroGuia  ConsultaImagen(int Id)
        {
            EntImagenesCarroGuia obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOImagenesCarroGuia Img = new DAOImagenesCarroGuia ();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.valor(Id);
            try
            {

                cmd = new SqlCommand("BuscarImagenCarroGuia", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenesCarroGuia ();
                dr.Read();

                obj.NombreDoc = dr["nombre"].ToString();
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

        public static bool DInsertar(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesCarroGuia ImgPagadas, int idTipoPago, int IdPasivo)
        {
            EntPersona PersonaMp = ObtenerIdMaestroProveedor(idPersona);
            int Us = ObtenerUsuario(idUsuario);
            string Resp = DInsertar1(fecha, idPersona, idUsuario, monto, ImgPagadas, idTipoPago, PersonaMp, Us, IdPasivo);
            if (Resp == "ok")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int EncontrarPeriodo(int IdPagadas)
        {
            int Periodo = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("select IdPeriodo  from ConciliacionCarroGuia where id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", IdPagadas);
                cmd.CommandType = CommandType.Text ;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Periodo  = Convert.ToInt32(dr["IdPeriodo"].ToString());

           
            }
            catch (Exception e)
            {
                Periodo  = 0;
                //obj.DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return Periodo  ; 

        }
        public static string EncontrarQuincena(int Periodo)
        {
            string Quincena = "";
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("select Quincena from Periodo where id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", Periodo );
                cmd.CommandType = CommandType.Text;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Quincena = Convert.ToString(dr["Quincena"].ToString());


            }
            catch (Exception e)
            {
                Quincena = "";
                //obj.DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return Quincena ; 
        }
        public static string DInsertar1(DateTime fecha, int idPersona, int idUsuario, double monto, EntImagenesCarroGuia ImgPagadas, int idTipoPago, EntPersona PersonaMp, int Us, int IdPasivo)
        {
            SqlConnection cnx = null;
            SqlCommand cmd = null;
            ClaseConexion Conexion = new ClaseConexion();
            string resp = "";
            int Periodo = EncontrarPeriodo(ImgPagadas.IdConciliacionCarroGuia);
            string Quincena =EncontrarQuincena(Periodo) ;
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
                    cmd.Parameters.AddWithValue("@glosa", "Liquidacion Carro Guia Perteneciente A " + PersonaMp.Nombres+" " +Quincena);
                    cmd.Parameters.AddWithValue("@cod_mod_pago", 103);
                    cmd.Parameters.AddWithValue("@sigla_banco", "FASSIL");
                    cmd.Parameters.AddWithValue("@nro_bancario", "909310");
                    cmd.Parameters.AddWithValue("@nro_doc_banco", "");
                    cmd.Parameters.AddWithValue("@nro_doc_bancario_original", "");
                    cmd.Parameters.AddWithValue("@fecha_documento", fecha); //parametro
                    cmd.Parameters.AddWithValue("@importe_total", monto); //parametro
                    cmd.Parameters.AddWithValue("@id_cuenta_contable", 369);
                    cmd.Parameters.AddWithValue("@beneficiario_cheque", "");
                    cmd.Parameters.AddWithValue("@id_banco_prov", "");
                    cmd.Parameters.AddWithValue("@usuario", Us); //parametro

                    int IdImgPagada = GuardarImagenAnidadaCarroGuia(ref cnx, ImgPagadas);
                    if (IdImgPagada > 0)
                    {

                        int fila = cmd.ExecuteNonQuery();
                        if (fila > 0)
                        {

                            resp = "ok";

                            int idOrden = Convert.ToInt32(idOrdenPago.Value);
                            resp = DGuardarDetalle(ref cnx, idOrden, monto, fecha, IdImgPagada, IdPasivo);
                            if (resp == "ok")
                                scope.Complete();
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
        public static string DGuardarDetalle(ref SqlConnection cnx, int idOrden, double monto, DateTime fecha, int IdImgPagada, int IdPasivo)
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
                cmd.Parameters.AddWithValue("@id_cta", 92);  //aqui idPasivo
                cmd.Parameters.AddWithValue("@id_pago", idOrden);
                cmd.Parameters.AddWithValue("@mat", 0);

                cmd.Parameters.AddWithValue("@idCodigo", IdImgPagada);
                cmd.Parameters.AddWithValue("@tabla_codigo", "ImagenesCarroGuia");

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

        public static int GuardarImagenAnidadaCarroGuia(ref SqlConnection cnx, EntImagenesCarroGuia  Obj)
        {
            int Id_ImagenCarroGuia = 0;
            SqlCommand cmd = null;
           

            try
            {

                if (Obj.Imagen != null)  //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update ImagenesCarroGuia set Estado = 0 where IdConciliacionCarroGuia= " + Obj.IdConciliacionCarroGuia, cnx);
                    
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into ImagenesCarroGuia (Imagen,nombre,ext,IdConciliacionCarroGuia,FechaPago) values (@Imagen,@nombre,@ext,@IdConciliacionCarroGuia,@FechaPago) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Imagen", Obj.Imagen);
                    cmd.Parameters.AddWithValue("@nombre", Obj.NombreDoc);
                    cmd.Parameters.AddWithValue("@ext", Obj.Ext);
                    cmd.Parameters.AddWithValue("@IdConciliacionCarroGuia", Obj.IdConciliacionCarroGuia);
                    cmd.Parameters.AddWithValue("@FechaPago", Obj.FechaPago);
                 
                    int Id_ImgCarroGuia = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenCarroGuia = Id_ImgCarroGuia;

                 
                }
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {

            }
            return Id_ImagenCarroGuia;
        }
        
    }
}