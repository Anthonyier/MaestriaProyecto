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
    public class DAOZkTeko
    {
        public static int Guardar(EntPersonaZkTeko ZkTe)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into PersonaZkTeko (IdZkteko,IdPersona) values (@MontoPagar,@MontoCobrar);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@MontoPagar", ZkTe.IdZkteko);
                cmd.Parameters.AddWithValue("@MontoCobrar",ZkTe.IdPersona);
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

        public static string ObtenerNombre(int IdZk)
        {
            string Nombre = "";
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select Persona.Nombre+' '+Persona.Apellidos as Nombres from Persona,PersonaZkTeko where Persona.Id_Persona=PersonaZkTeko.IdPersona and PersonaZkTeko.IdZktekoReset=@IdZk", cnx);
                cmd.Parameters.AddWithValue("@IdZk", IdZk );
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Nombre = dr["Nombres"].ToString();
            }
            catch (Exception e)
            {
                dr = null;
                return Nombre;
            }
            return Nombre;

        }
        public static int ObtenerIdZkteko(int IdPersona)
        {
            int id = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select IdZkteko from Persona,PersonaZkTeko where Persona.Id_Persona=PersonaZkTeko.IdPersona and Persona.Id_Persona=@Id",cnx);
                cmd.Parameters.AddWithValue("@Id",IdPersona);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                id = Convert.ToInt32(dr["IdZkteko"].ToString());
            }
            catch (Exception e)
            {
                dr = null;
                return id;
            }
            return id;
        }
    }
}