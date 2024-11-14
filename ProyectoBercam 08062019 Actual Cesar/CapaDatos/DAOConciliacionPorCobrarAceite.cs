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
    public class DAOConciliacionPorCobrarAceite
    {
        public static bool ModificarNroContrato(int Id, string NroContrato)
        {
            SqlCommand cmd = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            SqlTransaction myTrans = null;
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("ModificarContraroConcAceite", cnx);
                cmd.Parameters.AddWithValue("@IdConciliacion", Id);
                cmd.Parameters.AddWithValue("@NroContrato",NroContrato);
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
        public static int EstaAprobado(int id)
        {
            int Aprob = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("ObtenerConcPorCobrarAceite", cnx);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Aprob = Convert.ToInt32(dr["Aprobar"].ToString());//Convert.ToInt32(dr["Id_RecepcionManual"].ToString());

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
                cmd = new SqlCommand("AprobarConciliacionPorCobrarAceite", cnx);
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