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
    public class DAOTransaccion
    {
        public static int GuardarTransaccion(EntTransaccion Tran)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into Transaccion(Monto,TipoCambio,Glosa,IdMoneda,IdFormaPago,IdCuenta,IdTipoTransaccion) values (@Monto,"+
                    "@TipoCambio,@Glosa,@IdMoneda,@IdFormaPago,@IdCuenta,@IdTipoTransaccion);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Monto", Tran.Monto);
                cmd.Parameters.AddWithValue("@TipoCambio",Tran.TipoCambio);
                cmd.Parameters.AddWithValue("@Glosa", Tran.Glosa);
                cmd.Parameters.AddWithValue("@IdMoneda",Tran.IdMoneda);
                cmd.Parameters.AddWithValue("@IdFormaPago",Tran.IdFormaPago);
                cmd.Parameters.AddWithValue("@IdCuenta",Tran.IdCuenta);
                cmd.Parameters.AddWithValue("@IdTipoTransaccion", Tran.IdTipoTransaccion);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            myTrans.Commit();
            cnx.Close();
            return 1;

        }

        public static EntTransaccion ConsultaTransaccion(int IdTran)
        {
            EntTransaccion obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarTransaccion",cnx);
                cmd.Parameters.AddWithValue("@Transaccion",IdTran);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntTransaccion();
                dr.Read();
                obj.IdTransaccion = Convert.ToInt32(dr["IdTransaccion"].ToString());
                obj.Monto = Convert.ToDouble(dr["Monto"].ToString());
                obj.TipoCambio = Convert.ToDouble(dr["TipoCambio"].ToString());
                obj.Glosa = dr["Glosa"].ToString();
                obj.Estado = Convert.ToInt32(dr["Estado"].ToString());
                obj.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString());
                obj.IdMoneda = Convert.ToInt32(dr["IdMoneda"].ToString());
                obj.IdFormaPago = Convert.ToInt32(dr["IdFormaPago"].ToString());
                obj.IdCuenta = Convert.ToInt32(dr["IdCuenta"].ToString());
                obj.IdTipoTransaccion = Convert.ToInt32(dr["IdTipoTransaccion"].ToString());


            }
            catch(Exception e)
            {
                obj = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return obj;
        }

        public static int ActualizarTransaccion(EntTransaccion tran)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Transaccion set Monto=@Monto,TipoCambio=@TipoCambio,Glosa=@Glosa Where IdTransaccion=@IdTransaccion";
                cmd = new SqlCommand(sql,cnx);
                cmd.Parameters.AddWithValue("@Monto", tran.Monto);
                cmd.Parameters.AddWithValue("@TipoCambio",tran.TipoCambio);
                cmd.Parameters.AddWithValue("@Glosa", tran.Glosa);
                cmd.Parameters.AddWithValue("@IdTransaccion", tran.IdTransaccion);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                tran = null;
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
    }
}