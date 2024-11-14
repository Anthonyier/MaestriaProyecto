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
    public class DAOPermisosConciliaciones
    {
        public static int GuardarPermiso(EntPermisosConciliaciones  obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("ProcInserPermConc", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ListCobrRef", obj.ListCobrRef);
                cmd.Parameters.AddWithValue("@ListCobrCorp", obj.ListCobrCorp);
                cmd.Parameters.AddWithValue("@ListCobrAlc", obj.ListCobrAlc);
                cmd.Parameters.AddWithValue("@ListCobrAceite", obj.ListCobrAceite);
                cmd.Parameters.AddWithValue("@ListPagarRef", obj.ListPagarRef);
                cmd.Parameters.AddWithValue("@ListPagarCorp", obj.ListPagarCorp);
                cmd.Parameters.AddWithValue("@ListPagarAlc", obj.ListPagarAlc);
                cmd.Parameters.AddWithValue("@ListPagarAcei", obj.ListPagarAcei);
                cmd.Parameters.AddWithValue("@AsegRef", obj.AsegRef);
                cmd.Parameters.AddWithValue("@AsegCorp", obj.AsegCorp);
                cmd.Parameters.AddWithValue("@AsegAlc", obj.AsegAlc);
                cmd.Parameters.AddWithValue("@AsegAceite", obj.AsegAceite);
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

        public static EntPermisosConciliaciones  BuscarPermiso(int Id)
        {
            EntPermisosConciliaciones  obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarPermisoConciliaciones", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntPermisosConciliaciones();
                dr.Read();

                obj.ListCobrRef = Convert.ToInt32(dr["ListCobrRef"].ToString());
                obj.ListCobrCorp = Convert.ToInt32(dr["ListCobrCorp"].ToString());
                obj.ListCobrAlc = Convert.ToInt32(dr["ListCobrAlc"].ToString());
                obj.ListCobrAceite = Convert.ToInt32(dr["ListCobrAceite"].ToString());
                obj.ListPagarRef = Convert.ToInt32(dr["ListPagarRef"].ToString());
                obj.ListPagarCorp = Convert.ToInt32(dr["ListPagarCorp"].ToString());
                obj.ListPagarAlc  = Convert.ToInt32(dr["ListPagarAlc"].ToString());
                obj.ListPagarAcei = Convert.ToInt32(dr["ListPagarAcei"].ToString());
                obj.AsegRef = Convert.ToInt32(dr["AsegRef"].ToString());
                obj.AsegCorp = Convert.ToInt32(dr["AsegCorp"].ToString());
                obj.AsegAlc = Convert.ToInt32(dr["AsegAlc"]);
                obj.AsegAceite = Convert.ToInt32(dr["AsegAceite"]);
                obj.Cod_UsuaReg = Convert.ToInt32(dr["Cod_UsuaReg"].ToString());
                obj.AprobCobrRef = Convert.ToInt32(dr["AprobCobrRef"].ToString());
                obj.AprobCobrCorp = Convert.ToInt32(dr["AprobCobrCorp"].ToString());
                obj.AprobCobrAlc = Convert.ToInt32(dr["AprobCobrAlc"].ToString());
                obj.AprobCobrAcei = Convert.ToInt32(dr["AprobCobrAcei"].ToString());

            }
            catch (Exception e)
            {
                obj.ListCobrCorp = 0;
                obj.ListCobrRef = 0;
                obj.ListCobrAlc = 0;
                obj.ListCobrAceite = 0;
                obj.ListPagarRef = 0;
                obj.ListPagarCorp = 0;
                obj.ListPagarAlc  = 0;
                obj.ListPagarAcei = 0;
                obj.AsegRef = 0;
                obj.AsegCorp = 0;
                obj.AsegAlc = 0;
                obj.AsegAceite = 0;
                obj.Cod_UsuaReg = 0;
            }
            finally
            {
                cnx.Close();
            }
            return obj;
        }
    }
}