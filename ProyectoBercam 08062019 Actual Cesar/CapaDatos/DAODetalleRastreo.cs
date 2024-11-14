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
    public class DAODetalleRastreo
    {
        public static int Guardar(EntDetalleRastreo Dt)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into DetalleRastreo (MontoPagar,MontoCobrar,MontoCinabar,IdCamion,IdAño,IdMes) values (@MontoPagar,@MontoCobrar,@MontoCinabar,@IdCamion,@IdAño,@IdMes);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@MontoPagar", Dt.MontoPagar);
                cmd.Parameters.AddWithValue("@MontoCobrar", Dt.MontoCobrar);
                cmd.Parameters.AddWithValue("@MontoCinabar", Dt.MontoCinabar);
                cmd.Parameters.AddWithValue("@IdCamion", Dt.IdCamion);
                cmd.Parameters.AddWithValue("@IdAño", Dt.IdAño);
                cmd.Parameters.AddWithValue("@IdMes", Dt.IdMes );
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
        public static int GuardarGrupoRastreo(int Mes, int año)
        {
            EntDetalleRastreo obj = null;
            EntDetalleRastreo RastMax = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int NumRast = 0;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                NumRast = MaxRastreo();
                RastMax = ConsultaRastreo(NumRast);
                cmd = new SqlCommand("select * from DetalleRastreo where IdAño=@IdAño and IdMes=@IdMes", cnx);
                cmd.Parameters.AddWithValue("@IdAño", RastMax.IdAño);
                cmd.Parameters.AddWithValue("@IdMes", RastMax.IdMes);
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntDetalleRastreo();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        obj.MontoPagar = Double.Parse(dr["MontoPagar"].ToString());
                        obj.MontoCobrar = Double.Parse(dr["MontoCobrar"].ToString());
                        obj.MontoCinabar = Double.Parse(dr["MontoCinabar"].ToString());
                        obj.IdCamion = int.Parse(dr["IdCamion"].ToString());
                        obj.IdMes = Mes;
                        obj.IdAño = año;
                        obj.IdRastreo = 1;
                        Guardar(obj);
                    }
                }
                cnx.Close();
            }
            catch (Exception e)
            {
                obj = null;
            }

            return 1;
        }

        public static int MaxRastreo()
        {
            int Num = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select * from ViewRastreoMaximo", cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Num = Convert.ToInt32(dr["Id"].ToString());
            }
            catch (Exception e)
            {
                Num = 0;
            }
            finally
            {
                cnx.Close();
            }
            return Num;
        }

        public static EntDetalleRastreo ConsultaRastreo(int IdRast)
        {
            EntDetalleRastreo obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarEditarRastreo", cnx);
                cmd.Parameters.AddWithValue("@Id", IdRast);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntDetalleRastreo();
                dr.Read();
                obj.Id = Convert.ToInt32(dr["Id"].ToString());
                obj.MontoPagar = Convert.ToDouble(dr["MontoPagar"].ToString());
                obj.MontoCobrar = Convert.ToDouble(dr["MontoCobrar"].ToString());
                obj.MontoCinabar = Convert.ToDouble(dr["MontoCinabar"].ToString());
                obj.IdAño = Convert.ToInt32(dr["IdAño"].ToString());
                obj.IdMes = Convert.ToInt32(dr["IdMes"].ToString());
                obj.IdCamion = Convert.ToInt32(dr["IdCamion"].ToString());
                obj.IdRastreo = Convert.ToInt32(dr["IdRastreo"].ToString());
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

        public static int Actualizar(EntDetalleRastreo Ra)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = " Update DetalleRastreo set MontoPagar=@MontoPagar,MontoCobrar=@MontoCobrar,MontoCinabar=@MontoCinabar,IdCamion=@IdCamion,IdAño=@IdAño,IdMes=@IdMes where Id=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@MontoPagar", Ra.MontoPagar);
                cmd.Parameters.AddWithValue("@MontoCobrar",Ra.MontoCobrar);
                cmd.Parameters.AddWithValue("@MontoCinabar", Ra.MontoCinabar);
                cmd.Parameters.AddWithValue("@IdCamion", Ra.IdCamion);
                cmd.Parameters.AddWithValue("@IdAño", Ra.IdAño);
                cmd.Parameters.AddWithValue("@IdMes", Ra.IdMes);
                cmd.Parameters.AddWithValue("@Id", Ra.Id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                return 0;

            }
            myTrans.Commit();
            cnx.Close();
            return 1;
        }

    }
}