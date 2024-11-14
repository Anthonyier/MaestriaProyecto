using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DAOFrontera
    {

        public static EntFrontera BuscarFrontera(int Idetalle)
        {
            SqlCommand cmd = null;
            ClaseConexion conexion = new ClaseConexion();
            SqlConnection cnx = null;
            SqlDataReader dr = null;
            EntFrontera Frontera = null;
            try
            {
                cnx = new SqlConnection();
                cnx = conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("BuscarDatosFronteraDetalleProgram", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDetalle", Idetalle);
                dr = cmd.ExecuteReader();
                dr.Read();
                Frontera = new EntFrontera();

                Frontera.Id = Convert.ToInt32(dr["Id"].ToString());
                Frontera.NroCrt = dr["NroCrt"].ToString();
                Frontera.NroMic = dr["NroMic"].ToString();
                Frontera.NroDim = Convert.ToInt32(dr["NroDim"].ToString());
                Frontera.formatDim = dr["formatDim"].ToString();
                Frontera.NroPrm = dr["NroPrm"].ToString();
                Frontera.Nombre = dr["Nombre"].ToString();
            }
            catch (Exception ex)
            {
                Frontera = null;
            }
            finally
            {
                dr.Close();
                cnx.Close();
            }
            return Frontera;
        }
        public static EntFrontera BuscarFronteraPorNombre(string Nombre)
        {
            SqlCommand cmd = null;
            ClaseConexion conexion = new ClaseConexion();
            SqlConnection cnx = null;
            SqlDataReader dr = null;
            EntFrontera Frontera = null;
            try
            {
                cnx = new SqlConnection();
                cnx = conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("BuscarFronteraPorNombre", cnx);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                dr.Read();
                Frontera = new EntFrontera();
                Frontera.Id = Convert.ToInt32(dr["Id"].ToString());
                Frontera.NroCrt = dr["NroCrt"].ToString();
                Frontera.NroMic = dr["NroMic"].ToString();
                Frontera.NroDim = Convert.ToInt32(dr["NroDim"].ToString());
                Frontera.formatDim = dr["formatDim"].ToString();
                Frontera.NroPrm = dr["NroPrm"].ToString();
                Frontera.Nombre = dr["Nombre"].ToString();
            }
            catch (Exception ex)
            {
                Frontera = null;
            }
            finally
            {
                dr.Close();
                cnx.Close();
            }
            return Frontera;
        }
    }
}