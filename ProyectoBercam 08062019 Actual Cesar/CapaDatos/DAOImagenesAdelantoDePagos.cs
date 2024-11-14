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
    public class DAOImagenesAdelantoDePagos
    {
        public static int GuardarImagenes(EntImagenesAdelantoDePagos obj)//EntPersona obj, EntImagenes Ci, EntImagenes Licencia, EntImagenes Felcn, EntImagenes Rejap)
        {
            int Id_ImagenAdelanto = 0;
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
                    cmd = new SqlCommand("Update ImagenesAdelantoDePagos set Estado = 0 where IdAdelanto= " + obj.IdAdelanto, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into ImagenesAdelantoDePagos (Imagen,Nombre,Ext,IdAdelanto) values (@Imagen,@Nombre,@Ext,@IdAdelanto) ; SELECT Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Ext", obj.Ext);
                    cmd.Parameters.AddWithValue("@IdAdelanto", obj.IdAdelanto);
                    cmd.Transaction = myTrans;
                    int Id_ImgAdelanto = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_ImagenAdelanto= Id_ImgAdelanto ;

                    if (Id_ImagenAdelanto != 0)
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
            return Id_ImagenAdelanto;
        }

        public static int GuardarAdelTans(EntImagenesAdelantoDePagos obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            string sql = "";
            int Adel = 0;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                if (obj.Imagen != null)  //(Ci.Imagen != null)
                {
                    cmd = new SqlCommand("Update ImagenesAdelantoDePagos set Estado = 0 where IdAdelanto= " + obj.IdAdelanto, cnx);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Insert into ImagenesAdelantoDePagos (Imagen,Nombre,Ext,Estado,IdAdelanto) values (@Imagen,@Nombre,@Ext,@Estado,@IdAdelanto);SELECT Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Ext", obj.Ext);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("@IdAdelanto", obj.IdAdelanto);
                    cmd.Transaction = myTrans;
                    Adel = Convert.ToInt32(cmd.ExecuteScalar()); 
                    //cmd.ExecuteNonQuery();

          
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
            return Adel;
        }
        public static int ValorImagen(int IdAdelanto)
        {
            int obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ValorAltoAdelantoPago", cnx);
                cmd.Parameters.AddWithValue("@IdAdelanto", IdAdelanto);
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
        public int valor(int IdAdelanto)
        {
            int obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ValorAltoAdelantoPago", cnx);
                cmd.Parameters.AddWithValue("@IdAdelanto", IdAdelanto);
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
        public static EntImagenesAdelantoDePagos Download(int Id)
        {
            EntImagenesAdelantoDePagos  obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOImagenesAdelantoDePagos Img = new DAOImagenesAdelantoDePagos();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.valor(Id);
            try
            {

                cmd = new SqlCommand("BuscarImagenAdelantoPago", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenesAdelantoDePagos();
                dr.Read();

                obj.Nombre = dr["Nombre"].ToString();
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

        public static EntImagenesAdelantoDePagos ConsultaImagen(int Id)
        {
            EntImagenesAdelantoDePagos obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOImagenesAdelantoDePagos Img = new DAOImagenesAdelantoDePagos();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Img.valor(Id);
            try
            {

                cmd = new SqlCommand("BuscarImagenAdelantoPago", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntImagenesAdelantoDePagos();
                dr.Read();

                obj.Nombre = dr["Nombre"].ToString();
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