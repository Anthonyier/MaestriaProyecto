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
    public class DOADetalleImagen
    {
        public static int GuardarDetalleImagen(EntDetalleImagen obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            int Id_DetalleImg = 0;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into DeatlleImagen(Id_Imagen,Imagen,FechaVigencia,FechaRegistro)"
                    +"values(@Id_Imagen,@Imagen,@FechaVigencia,@FechaRegistro);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id_Imagen", obj.Id_Imagen);
                cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);
                cmd.Parameters.AddWithValue("@FechaVigencia", obj.FechaVigencia);
                cmd.Parameters.AddWithValue("@FechaRegistro", obj.FechaRegistro);
                cmd.Transaction = myTrans;
                Id_DetalleImg = Convert.ToInt32(cmd.ExecuteScalar());
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

        public static int ActualizarDetalleImagen(EntDetalleImagen obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update DetalleImagen set Imagen=@Imagen,FechaVigencia=@FechaVigencia,FechaRegistro=@FechaRegistro where Id_DetalleImg=@Id_DetalleImg";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);
                cmd.Parameters.AddWithValue("@FechaVigencia", obj.FechaVigencia);
                cmd.Parameters.AddWithValue("@FechaRegistro", obj.FechaRegistro);
                cmd.Parameters.AddWithValue("@Id_DetalleImg", obj.Id_DetalleImg);
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

    }
}