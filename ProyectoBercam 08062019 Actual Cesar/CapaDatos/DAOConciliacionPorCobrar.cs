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
    public class DAOConciliacionPorCobrar
    {
        public static EntConciliacionPorCobrar Consulta(int Id_Recepcion)
        {
            EntConciliacionPorCobrar obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarAsignacion", cnx);
                cmd.Parameters.AddWithValue("@Id_Recepcion", Id_Recepcion);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntConciliacionPorCobrar();
                dr.Read();
                obj.Recepcion = Convert.ToInt32(dr["Id_Recepcion"].ToString());
                obj.Cliente = dr["CLIENTE"].ToString();
                obj.Ruta = dr["Ruta"].ToString();
                obj.Producto = dr["PRODUCTO"].ToString();


            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return obj;
        }

        public static bool ModificarNumeroConc(int Id,string NumeroDeConciliacion)
        {
            SqlCommand cmd = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            SqlTransaction myTrans = null;
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("ModificarNumeroConciliacionRefinacion", cnx);
                cmd.Parameters.AddWithValue("@IdConciliacion", Id);
                cmd.Parameters.AddWithValue("@NumeroDeConciliacion", NumeroDeConciliacion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                return true;
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                return false;
            }
            finally
            {   
                cnx.Close();
            }
        }

        public static EntConciliacionPorCobrar Manual(int Id_Recepcion)
        {
            EntConciliacionPorCobrar obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarDetalleRe", cnx);
                cmd.Parameters.AddWithValue("@Id_Re", Id_Recepcion);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntConciliacionPorCobrar();
                dr.Read();
                obj.recepcionManual = dr["Id_RecepcionManual"].ToString();//Convert.ToInt32(dr["Id_RecepcionManual"].ToString());

            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return obj;
        }

        public static SqlDataReader BuscarRuta()
        {
            //EntConciliacionPorCobrar obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarRutas", cnx);
                //cmd.Parameters.AddWithValue("@Id_Re", Id_Recepcion);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                //obj = new EntConciliacionPorCobrar();
                //dr.Read();
                // obj.recepcionManual = Convert.ToInt32(dr["Id_RecepcionManual"].ToString());

            }
            catch (Exception e)
            {
                dr = null;
                //obj = null;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return dr;//obj;
        }

        public static int EstaAprobado(int id)
        {
            int Aprob = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("ObtenerConcPorCobrar", cnx);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Aprob= Convert.ToInt32(dr["Aprobar"].ToString());//Convert.ToInt32(dr["Id_RecepcionManual"].ToString());

            }
            catch (Exception e)
            {
              return 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return Aprob;
        }
        public static bool Aprobar(int id)
        {
            SqlCommand cmd = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            SqlTransaction myTrans = null;
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("AprobarConciliacionPorCobrar", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                return false;
            }
            finally
            {
                myTrans.Commit();
                cnx.Close();
               
            }
            return true;
        }

    }
}