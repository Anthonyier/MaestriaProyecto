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
    public class DAOPermisoCarroGuia
    {

        public static int GuardarPermiso(EntPermisosCarroGuias obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("ProcInserPermCarGuia", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CrearCarroGuia", obj.CrearCarroGuia);
                cmd.Parameters.AddWithValue("@CrearDetCarGuia", obj.CrearDetCarGuia);
                cmd.Parameters.AddWithValue("@CrearConcCarGuia", obj.CrearConcCarGuia);
                cmd.Parameters.AddWithValue("@ListDetCarroGuia", obj.ListDetCarroGuia);
                cmd.Parameters.AddWithValue("@ListConcCarroGuia", obj.ListConcCarrroGuia);
                cmd.Parameters.AddWithValue("@AprobCarroGuia", obj.AprobCarroGuia);
                cmd.Parameters.AddWithValue("@AsegCarroGuia", obj.AsegCarroGuia);
                cmd.Parameters.AddWithValue("@Cod_Usua", obj.Cod_Usua);
                cmd.Parameters.AddWithValue("@Cod_UsuaReg", obj.Cod_UsuaReg);
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

        public static void ModificarPermiso(EntPermisosCarroGuias obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("ProcModCamionGuia", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PagarAnticipo", obj.CrearCarroGuia);
                cmd.Parameters.AddWithValue("@CrearDetCarGuia", obj.CrearDetCarGuia);
                cmd.Parameters.AddWithValue("@CrearConcCarGuia", obj.CrearConcCarGuia);
                cmd.Parameters.AddWithValue("@ListDetCarroGuia", obj.ListDetCarroGuia);
                cmd.Parameters.AddWithValue("@ListConcCarroGuia", obj.ListConcCarrroGuia);
                cmd.Parameters.AddWithValue("@AprobCarroGuia", obj.AprobCarroGuia);
                cmd.Parameters.AddWithValue("@AsegCarroGuia", obj.AsegCarroGuia);
                cmd.Parameters.AddWithValue("@Cod_UsuaReg", obj.Cod_UsuaReg);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                obj = null;
                myTrans.Rollback();
                

            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
            
        }

        public static EntPermisosCarroGuias  BuscarPermiso(int Id)
        {
            EntPermisosCarroGuias obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarPermisoCarroGuia", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                obj = new EntPermisosCarroGuias();
                dr = cmd.ExecuteReader();
                dr.Read();
                obj.CrearCarroGuia = Convert.ToInt32(dr["CrearCarroGuia"].ToString());
                obj.CrearDetCarGuia = Convert.ToInt32(dr["CrearDetCarGuia"].ToString());
                obj.CrearConcCarGuia = Convert.ToInt32(dr["CrearConcCarGuia"].ToString());
                obj.ListDetCarroGuia = Convert.ToInt32(dr["ListDetCarroGuia"].ToString());
                obj.ListConcCarrroGuia=Convert.ToInt32(dr["ListConcCarroGuia"].ToString());
                obj.AprobCarroGuia = Convert.ToInt32(dr["AprobCarroGuia"].ToString());
                obj.AsegCarroGuia = Convert.ToInt32(dr["AsegCarroGuia"].ToString());
                obj.Cod_UsuaReg = Convert.ToInt32(dr["Cod_UsuaReg"].ToString());

            }
            catch (Exception e)
            {
                obj.CrearCarroGuia = 0;
                obj.CrearDetCarGuia = 0;
                obj.CrearConcCarGuia = 0;
                obj.ListConcCarrroGuia = 0;
                obj.ListDetCarroGuia = 0;
                obj.AsegCarroGuia = 0;
                obj.AprobCarroGuia = 0;
                return null;
            }
            finally
            {
                cnx.Close();
            }
            return obj;
        }
    }
}