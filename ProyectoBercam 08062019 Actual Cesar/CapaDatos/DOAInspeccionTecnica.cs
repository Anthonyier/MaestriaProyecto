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
    public class DOAInspeccionTecnica
    {
        public static int GuardarImagenes(EntInspTecnica obj)//EntPersona obj, EntImagenes Ci, EntImagenes Licencia, EntImagenes Felcn, EntImagenes Rejap)
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

                cmd = new SqlCommand("Update InspeccionTecnica set estado = 0 where Id_Camion= " + obj.Id_Camion, cnx);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Insert into InspeccionTecnica (F_Venc, Id_Camion) values (@F_Venc,@Id_Camion) ;SELECT  Scope_Identity(); ", cnx);
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

                cmd = new SqlCommand("ProcAltaInspecc", cnx);
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
        public static EntInspTecnica ConsultaVigencia(int CodEnte)
        {
            EntInspTecnica obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DOAInspeccionTecnica Ca = new DOAInspeccionTecnica();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Ca.valor(CodEnte);
            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("BuscarInspeccc", cnx);
                cmd.Parameters.AddWithValue("@Id_Insp", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntInspTecnica();
                dr.Read();

                obj.DiasVigencia = Convert.ToDouble(dr["DiasVigencia"].ToString());
                obj.F_Venc = Convert.ToDateTime(dr["F_Venc"].ToString());
                obj.DocumentNombre = dr["NombreDocumento"].ToString();

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
        public static SqlDataReader ObtenerListaInspeccionTecnica()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion con = new ClaseConexion();
                SqlConnection cnx = con.conectar();
                cmd = new SqlCommand("Select * from ViewListaInspec", cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                dr = null;
            }
            return dr;
        }
        public static EntInspTecnica Download(int Cod)
        {
            EntInspTecnica obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DOAInspeccionTecnica So = new DOAInspeccionTecnica();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = So.valor(Cod);
            try
            {

                cmd = new SqlCommand("BuscarInspeccc", cnx);
                cmd.Parameters.AddWithValue("@Id_Insp", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntInspTecnica ();
                dr.Read();

                obj.DiasVigencia = Convert.ToDouble(dr["DiasVigencia"].ToString());
                obj.F_Venc = Convert.ToDateTime(dr["F_Venc"].ToString());
                obj.DocumentNombre = dr["NombreDocumento"].ToString();
                obj.ImgIT = (byte[])dr["ImgIt"];
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
        public static DateTime ObtenerFecha(EntInspTecnica Obj)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntInspTecnica Cert = new EntInspTecnica();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select MAX(F_Venc) as F_Venc from InspeccionTecnica where Id_Camion=@IdCamion",cnx);
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