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
    public class DAOMaestroProveedor
    {
        public static int EncontrarIdMaestro(int IdTitular)
        {
            int IdMaestro = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select * from isi_vinculacion_proveedor  where idTitular=@IdTitular", cnx);
                cmd.Parameters.AddWithValue("@IdTitular", IdTitular);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdMaestro = int.Parse(dr["idMaestro_proveedor"].ToString());
            }
            catch (Exception e)
            {
                dr = null;
                IdMaestro = 0;
                return IdMaestro;
            }
            return IdMaestro;
        }

        public static int EncontrarIdAnticipo(int Id)
        {

            int IdAnticipo = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select id_anticipo from isi_maestro_proveedor where id=@Id", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdAnticipo = int.Parse(dr["id_anticipo"].ToString());
            }
            catch (Exception e)
            {
                dr = null;
                IdAnticipo = 0;
                return IdAnticipo;
            }
            return IdAnticipo;
        }
    }
}