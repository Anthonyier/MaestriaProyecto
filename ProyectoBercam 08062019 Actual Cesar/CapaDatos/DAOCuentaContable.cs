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
    public class DAOCuentaContable
    {
        public static int GuardarCuenta(EntCuentaContable Obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans=null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert Into CuentaContable(NumerodeOrden,NombredelaAccion,Id1Nivel,Id2Nivel,Id3Nivel,Id4Nivel,Id5Nivel,IdPadre) values(@NumerodeOrden,@NombredelaAccion,@Id1Nivel"+
                    ",@Id2Nivel,@Id3Nivel,@Id4Nivel,@Id5Nivel,@IdPadre);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@NumerodeOrden", Obj.NumerodeOrden);
                cmd.Parameters.AddWithValue("@NombredelaAccion",Obj.NombredelaAccion);
                cmd.Parameters.AddWithValue("@Id1Nivel", Obj.Id1Nivel);
                cmd.Parameters.AddWithValue("@Id2Nivel", Obj.Id2Nivel);
                cmd.Parameters.AddWithValue("@Id3Nivel",Obj.Id3Nivel);
                cmd.Parameters.AddWithValue("@Id4Nivel",Obj.Id4Nivel);
                cmd.Parameters.AddWithValue("@Id5Nivel",Obj.Id5Nivel);
                cmd.Parameters.AddWithValue("@IdPadre",Obj.Idpadre);
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

        public static int ActualizarCuenta(EntCuentaContable obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            //int Id_Pers = 0;
            double CI_Propietario = 0;
            int Id_ImgLicenciaConducir = 0;
            int Id_ImgAntFELCN = 0;
            int Id_ImgAntPenalesRejap = 0;
            double CI_TitularBanco = 0;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();

                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Update CuentaContable set NumerodeOrden = @NumerodeOrden,NombredelaAccion = @NombredelaAccion " +
                "where Id = @Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@NumerodeOrden", obj.NumerodeOrden);
                cmd.Parameters.AddWithValue("@NombredelaAccion", obj.NombredelaAccion);
                
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                //hasta aqui
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

        public static EntCuentaContable BuscarCuenta(int Id)
        {
            EntCuentaContable obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                
                cmd = new SqlCommand("BuscarCuenta",cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntCuentaContable();
                dr.Read();
                obj.Id = Convert.ToInt32(dr["Id"].ToString());
                obj.NumerodeOrden = dr["NumerodeOrden"].ToString();
                obj.NombredelaAccion = dr["NombredelaAccion"].ToString();
                obj.Id1Nivel = Convert.ToInt32(dr["N1"].ToString());
                obj.Id2Nivel = Convert.ToInt32(dr["N2"].ToString());
                obj.Id3Nivel = Convert.ToInt32(dr["N3"].ToString());
                obj.Id4Nivel = Convert.ToInt32(dr["N4"].ToString());
                obj.Id5Nivel = Convert.ToInt32(dr["N5"].ToString());
                obj.Idpadre = Convert.ToInt32(dr["IdPadre"].ToString());
            }
            catch (Exception e)
            {
               obj = null;
                
            }
            finally
            {
                cnx.Close();
            }
            return obj;
        }

        public static int cant(int id)
        {
            int n = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("CantOrden", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                n = Convert.ToInt32(dr["cantidad"].ToString());
         
            }
            catch (Exception e)
            {
                n = 0;

            }
            finally
            {
                cnx.Close();
            }
            return n;
        }

        public static SqlDataReader BuscarNombre(string Nom)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("EncontrarCuenta", cnx);
                cmd.Parameters.AddWithValue("@Nombre", Nom);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                //obj = new EntCamiones();
                //dr.Read();

                return dr;
            }
            catch (Exception e)
            {
                //obj = null;
                dr = null;
                return dr;
            }
            finally
            {

            }

        }

        public static SqlDataReader Niveles(int id)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcNivel", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
               
                return dr;
            }
            catch (Exception e)
            {
                //obj = null;
                dr = null;
                return dr;
            }
            finally
            {

            }
        }

        public static EntCuentaContable ModCuenta(int id)
        {
            EntCuentaContable obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("ModCuenta", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntCuentaContable();
                dr.Read();
                obj.Id = Convert.ToInt32(dr["Id"].ToString());
                obj.NumerodeOrden = dr["NumerodeOrden"].ToString();
                obj.NombredelaAccion = dr["NombredelaAccion"].ToString();
                obj.Idpadre = Convert.ToInt32(dr["IdPadre"].ToString());

            }
            catch (Exception e)
            {
                obj = null;

            }
            finally
            {
                cnx.Close();
            }
            return obj;
                //cmd = new SqlCommand("ModCuenta", cnx);
               
        }
    }
}