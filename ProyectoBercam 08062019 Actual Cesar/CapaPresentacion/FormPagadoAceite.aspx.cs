using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class FormPagadoAceite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarMes();
                CargarCliente();
            }
        }

        public void CargarAño()
        {
            cmAño.Items.Clear();
            cmAño.Items.Add(new ListItem("--Seleccione Año--", ""));
            cmAño.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "Select * From Año";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                cmAño.DataSource = dr;
                cmAño.DataTextField = "Descripcion";
                cmAño.DataValueField = "Id";
                cmAño.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
        public void CargarCliente()
        {
            cmCliente.Items.Clear();
            cmCliente.Items.Add(new ListItem("--Seleccione el Cliente--"));
            cmCliente.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT  Nombre +' '+ Apellidos As Nombre,Id_Persona FROM Persona,ConciliacionPorCobrarAceite where Persona.Id_Persona=ConciliacionPorCobrarAceite.IdPersona "
                 + "group by Nombre,Apellidos,Id_Persona";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                cmCliente.DataSource = dr; //cmd.ExecuteReader();    
                cmCliente.DataTextField = "Nombre";
                cmCliente.DataValueField = "Id_Persona";
                cmCliente.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
        public DataTable GetPagadoAceite(int IdMes,int IdAño, int IdPersona)
        {
            DataTable dtPagadoAceite = new DataTable();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlDataReader dr = null;
            try
            {
                SqlCommand cmd = new SqlCommand("ProcPagadoAceite", cnx);
                cmd.Parameters.AddWithValue("@IdMes",IdMes);
                cmd.Parameters.AddWithValue("@IdAño", IdAño);
                cmd.Parameters.AddWithValue("@IdPersona", IdPersona);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dtPagadoAceite.Load(dr);
            }
            catch (Exception e)
            {
                dr = null;
                return dtPagadoAceite;
            }

            return dtPagadoAceite;
        }

        public void CargarMes()
        {
            cmMes.Items.Clear();
            cmMes.Items.Add(new ListItem("--Seleccione el Mes--", ""));
            cmMes.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Mes";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                cmMes.DataSource = dr; //cmd.ExecuteReader();    
                cmMes.DataTextField = "Descripcion";
                cmMes.DataValueField = "id";
                cmMes.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            DataTable tabla = new System.Data.DataTable();
            int Mes = int.Parse(cmMes.Text);
            int Año = int.Parse(cmAño.Text);
            int Persona = int.Parse(cmCliente.Text);
            tabla = GetPagadoAceite(Mes, Año, Persona);
            GridView1.DataSource = tabla;
            GridView1.DataBind();
        }
    }
}