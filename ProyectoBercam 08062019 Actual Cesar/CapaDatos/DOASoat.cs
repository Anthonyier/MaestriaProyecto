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
    public class DOASoat
    {
        public static int GuardarImagenes(EntSoat obj)//EntPersona obj, EntImagenes Ci, EntImagenes Licencia, EntImagenes Felcn, EntImagenes Rejap)
        {
            int Id_ImagenCI = 0;
            
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            string sql = "";

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                cmd = new SqlCommand("Update Soat set estado = 0 where Id_Camion= " + obj.Id_Camion, cnx);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Insert into Soat (F_Venc, Id_Camion) values (@F_Venc,@Id_Camion) ;SELECT  Scope_Identity(); ", cnx);
                //(" + obj.Cod_Ente + "," + "'" + obj.Imagen + "'" + "," + "'" + obj.Vigencia + "'" + "," + obj.Tipo_Imagen
                //+ ");SELECT  Scope_Identity();", cnx);
                cmd.Parameters.AddWithValue("@F_Venc", obj.F_Venc);
                cmd.Parameters.AddWithValue("@Id_Camion", obj.Id_Camion);
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

        public int valor(int Id)
        {
            int obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ProcAltoSoat", cnx);
                cmd.Parameters.AddWithValue("@Id_Camion", Id);
               
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
        public static SqlDataReader ObtenerListaSOAT()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion con = new ClaseConexion();
                SqlConnection cnx = con.conectar();
                cmd = new SqlCommand("Select * from ViewListaSoat", cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                dr = null;
            }
            return dr;
        }
        public static EntSoat ConsultaVigencia(int CodEnte)
        {
            EntSoat obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DOASoat Ca = new DOASoat();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Ca.valor(CodEnte);
            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("BuscarSoat", cnx);
                cmd.Parameters.AddWithValue("@Id_Soat", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntSoat();
                dr.Read();

                obj.DiasVigencia = Convert.ToDouble(dr["DiasVigencia"].ToString());
                obj.F_Venc = Convert.ToDateTime(dr["F_Venc"].ToString());
                obj.DocumentNombre = dr["NombreDoc"].ToString();
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
            return obj; //objDiasVigenciaCI;//obj.DiasVigenciaCI;//obj;
        }

        public static EntSoat  Download(int Cod)
        {
            EntSoat obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DOASoat So = new DOASoat();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = So.valor(Cod);
            try
            {

                cmd = new SqlCommand("BuscarSoat", cnx);
                cmd.Parameters.AddWithValue("@Id_Soat", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntSoat();
                dr.Read();

                obj.DiasVigencia = Convert.ToDouble(dr["DiasVigencia"].ToString());
                obj.F_Venc = Convert.ToDateTime(dr["F_Venc"].ToString());
                obj.DocumentNombre = dr["NombreDoc"].ToString();
                obj.ImgSoat = (byte[])dr["ImgSoat"];
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
        public static DateTime ObtenerFecha(EntSoat Obj)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntSoat Cert = new EntSoat();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select MAX(F_Venc) as F_Venc from Soat where Id_Camion=@IdCamion",cnx);
                cmd.Parameters.AddWithValue("@IdCamion", Obj.Id_Camion);
                cmd.CommandType = CommandType.Text;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Cert.F_Venc = Convert.ToDateTime(dr["F_Venc"].ToString());
                if (Cert.F_Venc == null)
                {
                    Cert.F_Venc = Convert.ToDateTime("01/01/2021");
                    return Cert.F_Venc;
                }
                else
                {
                    return Cert.F_Venc;
                }
            }
            catch (Exception ex)
            {
                Cert.F_Venc = Convert.ToDateTime("01/01/2021");
            }
            return Cert.F_Venc;
        }
    }
}