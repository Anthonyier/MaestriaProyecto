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
    public class DOAMulta
    {
        public static int GuardarMulta(EntMulta Mu)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into Multa(Concepto,Multa,IdCliente) values(@Concepto,@Multa,@IdCliente);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Concepto", Mu.Concepto);
                cmd.Parameters.AddWithValue("@Multa", Mu.Multa);
                cmd.Parameters.AddWithValue("@IdCliente", Mu.IdCliente);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                //sql = "Update Camiones set OBS=@Obs where Placa=@Placa";
                //cmd = new SqlCommand(sql, cnx);
                //cmd.Parameters.AddWithValue("@Placa", Placa);
                //cmd.Parameters.AddWithValue("@Obs", Obs);
                //cmd.Transaction = myTrans;
                //cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();

            }
            myTrans.Commit();
            cnx.Close();
            return 1;
        }

        public static int ActualizarMulta(EntMulta Mu)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Multa set Concepto=@Concepto,Multa=@Multa where id=@id";
                cmd = new SqlCommand(sql, cnx);
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Concepto", Mu.Concepto);
                cmd.Parameters.AddWithValue("@Multa", Mu.Multa);
                cmd.Parameters.AddWithValue("@id", Mu.id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                //sql = "Update Camiones set OBS=@Obs where Placa=@Placa";
                //cmd = new SqlCommand(sql, cnx);
                //cmd.Parameters.AddWithValue("@Placa", Placa);
                //cmd.Parameters.AddWithValue("@Obs", Obs);
                //cmd.Transaction = myTrans;
                //cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
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

        public static EntMulta BuscarMulta(int IdMulta)
        {
            EntMulta obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("BuscarMulta",cnx);
                cmd.Parameters.AddWithValue("@IdMulta", IdMulta);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                obj = new EntMulta();
                dr = cmd.ExecuteReader();
                dr.Read();
                obj.id = Convert.ToInt32(dr["id"].ToString());
                obj.Concepto = dr["Concepto"].ToString();
                obj.Multa  = Convert.ToDouble (dr["Multa"].ToString());
                obj.Estado = Convert.ToInt32(dr["Estado"].ToString());
                obj.IdCliente = int.Parse(dr["IdCliente"].ToString());
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

        public static int DeshabilitarMulta(int id)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();

                cnx.Open();
                myTrans = cnx.BeginTransaction();

                ////string sql = "Insert into Persona (CI, Tipo_Persona, Id_TipoPersonaPRO, Id_TipoPersonaCho, Id_TipoPersonaTit, Id_TipoPersonaUs, Nombres, Apellidos, Direccion, Telefonos, TelfReferencia, Email, VigenciaCI, VigenciaLicencia, VigenciaFelcn, VigenciaRejap) values(@CI, @Tipo_Persona, @Id_TipoPersonaPRO, @Id_TipoPersonaCho, @Id_TipoPersonaTit, @Id_TipoPersonaUs, @Nombres, @Apellidos, @Direccion, @Telefonos, @TelfReferencia, @Email, @VigenciaCI, @VigenciaLicencia, @VigenciaFelcn, @VigenciaRejap) ;SELECT  Scope_Identity(); ";

                string sql = "Update Multa set Estado=0 where id=@id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                //hasta aqui
            }
            catch (Exception e)
            {

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