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
    public class DAOPermisoRutas
    {
        public static int GuardarPermiso(EntPermisoRutas obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into PermisoRutas (CrearRuta,ModificarRutas,ProgramaRutas,ListaProgram,ModificacionProgramacion,ListaRutas," +
                "AnularRutas,ConciliacionCobrar,Cod_Usua,Cod_UsuaReg,ConfirmarRuta,NoDespachado,Aplicacion,Dim,ConfDescarga)" +
                "values (@CrearRuta,@ModificarRutas,@ProgramaRutas,@ListaProgram,@ModificacionProgramacion,@ListaRutas,@AnularRutas,@ConciliacionCobrar,@Cod_Usua"+
                ",@Cod_UsuaReg,@ConfirmarRuta,@NoDespachado,@Aplicacion,@Dim,@ConfDescarga);";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@CrearRuta", obj.CrearRuta);
                cmd.Parameters.AddWithValue("@ModificarRutas",obj.ModificarRutas);
                cmd.Parameters.AddWithValue("@ProgramaRutas", obj.ProgramaRutas);
                cmd.Parameters.AddWithValue("@ListaProgram",obj.ListaProgram);
                cmd.Parameters.AddWithValue("@ModificacionProgramacion", obj.ModificarProgramacion);
                cmd.Parameters.AddWithValue("@ListaRutas", obj.ListaRutas);
                cmd.Parameters.AddWithValue("@AnularRutas", obj.AnularRutas);
                cmd.Parameters.AddWithValue("@ConciliacionCobrar", obj.ConciliacionCobrar);
                cmd.Parameters.AddWithValue("@Cod_Usua", obj.Cod_Usua);
                cmd.Parameters.AddWithValue("@Cod_UsuaReg", obj.Cod_UsuaReg);
                cmd.Parameters.AddWithValue("@ConfirmarRuta", obj.ConfirmarRuta);
                cmd.Parameters.AddWithValue("@NoDespachado", obj.NoDespachado);
                cmd.Parameters.AddWithValue("@Aplicacion", obj.Aplicacion);
                cmd.Parameters.AddWithValue("@Dim", obj.Dim);
                cmd.Parameters.AddWithValue("@ConfDescarga", obj.ConfDescarga);
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

        public static EntPermisoRutas BuscarPermiso(int Id)
        {
            EntPermisoRutas obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarPermisoRutas", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntPermisoRutas();
                dr.Read();

                obj.CrearRuta = Convert.ToInt32(dr["CrearRuta"].ToString());
                obj.ModificarRutas = Convert.ToInt32(dr["ModificarRutas"].ToString());
                obj.ProgramaRutas = Convert.ToInt32(dr["ProgramaRutas"].ToString());
                obj.ListaProgram = Convert.ToInt32(dr["ListaProgram"].ToString());
                obj.ModificarProgramacion = Convert.ToInt32(dr["ModificacionProgramacion"].ToString());
                obj.ListaRutas = Convert.ToInt32(dr["ListaRutas"].ToString());
                obj.AnularRutas = Convert.ToInt32(dr["AnularRutas"].ToString());
                obj.ConciliacionCobrar = Convert.ToInt32(dr["ConciliacionCobrar"].ToString());
                obj.Cod_UsuaReg = Convert.ToInt32(dr["Cod_UsuaReg"].ToString());
                obj.ConfirmarRuta = Convert.ToInt32(dr["ConfirmarRuta"].ToString());
                obj.NoDespachado = Convert.ToInt32(dr["NoDespachado"].ToString());
                obj.Aplicacion = Convert.ToInt32(dr["Aplicacion"].ToString());
                obj.Dim = Convert.ToInt32(dr["Dim"].ToString());
                obj.ConfDescarga = Convert.ToInt32(dr["confdescarga"].ToString());
            }
            catch (Exception e)
            {
                obj.CrearRuta = 0;
                obj.ModificarRutas = 0;
                obj.ProgramaRutas = 0;
                obj.ListaProgram = 0;
                obj.ModificarProgramacion = 0;
                obj.ListaRutas = 0;
                obj.AnularRutas = 0;
                obj.ConciliacionCobrar = 0;
                obj.Cod_UsuaReg = 0;
            }
            finally
            {
                cnx.Close();
            }
            return obj;
        }
    }
}