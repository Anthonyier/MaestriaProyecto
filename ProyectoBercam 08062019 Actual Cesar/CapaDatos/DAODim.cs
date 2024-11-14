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
    public class DAODim
    {
        public static int InsertarDim(string Dim,string Producto, string Proveedor,string AduanaFrontera,List<EntDetalleDim>Lista)
        {
            SqlCommand cmd = null;
            int resp = 0;
            string respues = "Ok";
            SqlConnection cnx = null;
            ClaseConexion Conexion = new ClaseConexion();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    cnx = new SqlConnection();
                    cnx = Conexion.conectar();
                    cnx.Open();
                    cmd = new SqlCommand("ProcInsertarDim", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter IdDim = new SqlParameter("@Id", SqlDbType.Int);
                    IdDim.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(IdDim);
                    cmd.Parameters.AddWithValue("@Dim", Dim);
                    cmd.Parameters.AddWithValue("@Producto", Producto);
                    cmd.Parameters.AddWithValue("@Proveedor", Proveedor);
                    cmd.Parameters.AddWithValue("@AduanaFrontera", AduanaFrontera);
                    int fila = cmd.ExecuteNonQuery();
                    if (fila > 0)
                    {
                        resp = 1;
                        int Id = Convert.ToInt32(IdDim.Value);
                        for (int i = 0; i < Lista.Count(); i++)
                        {
                            respues = DAODetalleDim.InsDetalleDim(ref cnx, Lista[i],Id);
                        }
                        if (respues == "ok")
                        {
                            scope.Complete();
                            resp = 1;
                        }
                    }
                    else
                    {
                        resp = 0;
                    }
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
        public static int AddDim(string Dim,string producto,string proveedor,string AduanaFrontera)
        {
            SqlCommand cmd = null;
            int resp = 0;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = null;
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("ProcInsertarDim", cnx);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dim", Dim);
                cmd.Parameters.AddWithValue("@Producto", producto);
                cmd.Parameters.AddWithValue("@Proveedor", proveedor);
                cmd.Parameters.AddWithValue("@AduanaFrontera", AduanaFrontera);
                int fila = cmd.ExecuteNonQuery();
                if (fila > 0)
                {
                    resp = 1;
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
        public static int ModificarDim(int Id, string Dim, string Producto, string Proveedor, string AduanaFrontera)
        {
            SqlCommand cmd = null;
            int resp = 0;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = null;
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                cmd=new SqlCommand("Isi_ActualizarDim",cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDim", Id);
                cmd.Parameters.AddWithValue("@Dim", Dim);
                cmd.Parameters.AddWithValue("@Producto", Producto);
                cmd.Parameters.AddWithValue("@Proveedor", Proveedor);
                cmd.Parameters.AddWithValue("@AduanaFrontera", AduanaFrontera);
                int fila = cmd.ExecuteNonQuery();
                if (fila > 0)
                {
                    resp = 1;
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
        public static int DesactivarDim(int Id)
        {
            SqlCommand cmd = null;
            int resp = 0;
            ClaseConexion conexion = new ClaseConexion();
            SqlConnection cnx = null;
            try
            {
                cnx = new SqlConnection();
                cnx = conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("IsiDesactivarDim", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                int fila = cmd.ExecuteNonQuery();
                if (fila > 0)
                {
                    resp = 1;
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
        public static bool CerrarDim(int Id)
        {
            SqlCommand cmd = null;
            bool resp = false;
            ClaseConexion conexion = new ClaseConexion();
            SqlConnection cnx = null;
            try
            {
                cnx = new SqlConnection();
                cnx = conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("ProcCerrarDim", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                int fila = cmd.ExecuteNonQuery();
                if (fila > 0)
                {
                    resp = true;
                }
                else
                {
                    resp = false;
                }
            }
            catch (Exception ex)
            {
                resp = false;
            }
            finally
            {
                cnx.Close();
            }
            return resp;
        }
        public static int EncontrarDimCerrado(int Dim)
        {
            SqlCommand cmd = null;
            int EstDim = 0;
            ClaseConexion conexion = new ClaseConexion();
            SqlConnection cnx = null;
            SqlDataReader dr = null;
            try
            {
                cnx = new SqlConnection();
                cnx = conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("ProcEstadoDimCerrado", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Dim);
                dr = cmd.ExecuteReader();
                dr.Read();
                EstDim = Convert.ToInt32(dr["EstCerrado"].ToString());
            }
            catch (Exception ex)
            {
                EstDim = 0;
            }
            finally
            {
                cnx.Close();
            }
            return EstDim;
        }
        public static EntDim BuscarDim(int IdDim)
        {
            SqlCommand cmd = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = null;
            SqlDataReader dr = null;
            EntDim ObjDim = null;
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("ProcBuscarDim", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", IdDim);
                dr = cmd.ExecuteReader();
                ObjDim = new EntDim();
                dr.Read();

                ObjDim.Id = Convert.ToInt32(dr["Id"].ToString());
                ObjDim.Dim = dr["Dim"].ToString();
                ObjDim.Producto = dr["Producto"].ToString();
                ObjDim.Proveedor = dr["Proveedor"].ToString();
                ObjDim.FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString());
                ObjDim.AduanaFrontera = dr["AduanaFrontera"].ToString();
                ObjDim.EstCerrado = Convert.ToInt32(dr["EstCerrado"].ToString());

            }
            catch (Exception ex)
            {
                ObjDim = null;
            }
            finally
            {
                cnx.Close();
            }
            return ObjDim;
        }

        public static int BuscarDimExistente(string Dim)
        {
            SqlCommand cmd = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = null;
            SqlDataReader dr = null;
            int NroDim = 0;
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                cmd = new SqlCommand("BuscarDimExistente", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dim", Dim);
                dr = cmd.ExecuteReader();
                dr.Read();
                NroDim = Convert.ToInt32(dr["Id"].ToString());
            }
            catch (Exception ex)
            {
                NroDim = 0;
                return 0;
            }
            finally
            {
                cnx.Close();
            }
            return 1;
        }
    }
}