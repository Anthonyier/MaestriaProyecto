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
    public class DAODetalleTelefono
    {
        public static int Guardar(EntDetalleTelefono Dt)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into DetalleTelefono (Numero,MontoCobrar,Credito,Personal,Libre,IdCamion,IdAño,IdMes) values (@Numero,@MontoCobrar,@Credito,@Personal,@Libre,@IdCamion,@IdAño,@IdMes);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Numero", Dt.Numero);
                cmd.Parameters.AddWithValue("@MontoCobrar", Dt.MontoCobrar);
                cmd.Parameters.AddWithValue("@Credito", Dt.Credito);
                cmd.Parameters.AddWithValue("@Personal", Dt.Personal);
                cmd.Parameters.AddWithValue("@Libre", Dt.Libre);
                cmd.Parameters.AddWithValue("@IdCamion", Dt.IdCamion);
                cmd.Parameters.AddWithValue("@IdAño", Dt.IdAño);
                cmd.Parameters.AddWithValue("@IdMes", Dt.IdMes);
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

        public static int MaxTelefeno()
        {
            int Num = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select * from ViewTelefoniaMaxima", cnx);
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

        public static EntDetalleTelefono ConsultaTodo(int IdTelf)
        {
            EntDetalleTelefono obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarEditarTelefono", cnx);
                cmd.Parameters.AddWithValue("@Id", IdTelf);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntDetalleTelefono();
                dr.Read();
                obj.Id = Convert.ToInt32(dr["Id"].ToString());
                obj.MontoCobrar = Convert.ToDouble(dr["MontoCobrar"].ToString());
                obj.Credito = Convert.ToDouble(dr["Credito"].ToString());
                obj.Numero = dr["Numero"].ToString();
                obj.Personal = dr["Personal"].ToString();
                obj.Libre = Convert.ToInt32(dr["Libre"].ToString());
                obj.Estado = Convert.ToInt32(dr["Estado"].ToString());
                obj.IdAño = Convert.ToInt32(dr["IdAño"].ToString());
                obj.IdMes = Convert.ToInt32(dr["IdMes"].ToString());
                obj.IdCamion = Convert.ToInt32(dr["IdCamion"].ToString());

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

        public static int Actualizar(EntDetalleTelefono Te)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = " Update DetalleTelefono set Numero=@Numero,MontoCobrar=@MontoCobrar,Credito=@Credito,Personal=@Personal,Libre=@Libre,IdCamion=@IdCamion,IdAño=@IdAño,IdMes=@IdMes where Id=@Id and Estado=0";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Numero", Te.Numero);
                cmd.Parameters.AddWithValue("@MontoCobrar", Te.MontoCobrar);
                cmd.Parameters.AddWithValue("@Credito", Te.Credito);
                cmd.Parameters.AddWithValue("@Personal", Te.Personal);
                cmd.Parameters.AddWithValue("@Libre", Te.Libre);
                cmd.Parameters.AddWithValue("@IdCamion", Te.IdCamion);
                cmd.Parameters.AddWithValue("@IdAño", Te.IdAño);
                cmd.Parameters.AddWithValue("@IdMes", Te.IdMes);
                cmd.Parameters.AddWithValue("@Id", Te.Id);
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

        public static int GuardarGrupoTelefono(int Mes, int año)
        {
            EntDetalleTelefono obj = null;
            EntDetalleTelefono TelfObj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int maxTelf = 0;
            try
            {
                maxTelf = MaxTelefeno();
                TelfObj = ConsultaTodo(maxTelf);
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select * from DetalleTelefono where IdAño=@IdAño and IdMes=@IdMes", cnx);
                cmd.Parameters.AddWithValue("@IdAño", TelfObj.IdAño);
                cmd.Parameters.AddWithValue("@IdMes", TelfObj.IdMes);
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntDetalleTelefono();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        obj.MontoCobrar = Double.Parse(dr["MontoCobrar"].ToString());
                        obj.Credito = Double.Parse(dr["Credito"].ToString());
                        obj.Numero = dr["Numero"].ToString();
                        obj.Personal = dr["Personal"].ToString();
                        obj.Libre = int.Parse(dr["Libre"].ToString());
                        obj.IdCamion = int.Parse(dr["IdCamion"].ToString());
                        obj.IdMes = Mes;
                        obj.IdAño = año;
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

        public static void EliminarTelefono(int Id)
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

                string sql = "delete from DetalleTelefono where Id=@Id and Estado=0";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                //hasta aqui
            }
            catch (Exception e)
            {

                myTrans.Rollback();
              

            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
    }
}