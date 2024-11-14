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
    public class DAOAplicacion
    {
        public static int InsertarAplicacion(EntAplicacion EntApli)
        {
            SqlCommand cmd = null;
            int resp = 0;
            SqlConnection cnx = null;
            ClaseConexion Conexion = new ClaseConexion();
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("Isi_GuardarAplicacionDim", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Asegurado",EntApli.Asegurado);
                cmd.Parameters.AddWithValue("@Asegurado_Adicional", EntApli.Asegurado_Adicional);
                cmd.Parameters.AddWithValue("@Producto_Asegurado", EntApli.Producto_Asegurado);
                cmd.Parameters.AddWithValue("@Volumen_Transportado", EntApli.Volumen_Transportado);
                cmd.Parameters.AddWithValue("@Valor_Asegurado", EntApli.Valor_Asegurado);
                cmd.Parameters.AddWithValue("@NumeroDeDim", EntApli.NumeroDim);
                cmd.Parameters.AddWithValue("@MedioDeTransporte", EntApli.MedioDeTransporte);
                cmd.Parameters.AddWithValue("@LimiteMaximoPorEmbarque", EntApli.LimiteMaximoEmbarque);
                cmd.Parameters.AddWithValue("@Travesia", EntApli.Travesia);
                cmd.Parameters.AddWithValue("@FronteraDeIngreso", EntApli.FronteraDeIngreso);
                cmd.Parameters.AddWithValue("@Coberturas", EntApli.Coberturas);
                cmd.Parameters.AddWithValue("@PeriodoCargaDesde", EntApli.PeriodoCargaDesde);
                cmd.Parameters.AddWithValue("@PeriodoCargaHasta", EntApli.PeriodoCargaHasta);
                cmd.Parameters.AddWithValue("@Deducible", EntApli.Deducible);
                cmd.Parameters.AddWithValue("@PrimaTotal", EntApli.PrimaTotal);
                cmd.Parameters.AddWithValue("@FormaDePago", EntApli.FormaDePago);
                cmd.Parameters.AddWithValue("@IdDim", EntApli.IdDim);
                cmd.Parameters.AddWithValue("@PrecioPromedio", EntApli.PrecioPromedio);
                int fila = cmd.ExecuteNonQuery();
                if (fila > 0)
                {
                    resp=1;
                }
                else
                {
                    resp = 0;
                }
            }
            catch (Exception ex)
            {
                resp = 0;
            }
            finally
            {
                cnx.Close();
            }
            return resp;
        }
        public static int EncontrarDimAplicado(int IdDim)
        {
            SqlCommand cmd = null;
            int Dim = 0;
            ClaseConexion conexion = new ClaseConexion();
            SqlConnection cnx = null;
            SqlDataReader dr = null;
            try
            {
                cnx = new SqlConnection();
                cnx = conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("BuscarDimAplicacion", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Iddim", IdDim);
                dr = cmd.ExecuteReader();
                dr.Read();
                Dim = Convert.ToInt32(dr["IdDim"].ToString());
            }
            catch (Exception ex)
            {
                Dim = 0;
            }
            finally
            {
                cnx.Close();
            }
            return Dim;
        }
    }
}